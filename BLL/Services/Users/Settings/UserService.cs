using API.Auth;
using AutoMapper;
using BLL.Models.User;
using DAL.Models.Entities.User;
using DAL.UnitsOfWork;
using Microsoft.Extensions.Logging;

namespace BLL.Services.Users.Settings
{
    public class UserService : IUserService
    {
        private UnitOfWorkPlatform _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork is not null && unitOfWork is UnitOfWorkPlatform)
            {
                _unitOfWork = unitOfWork as UnitOfWorkPlatform;
            }
            else
            {
                _unitOfWork = new UnitOfWorkPlatform();
            }

            _mapper = mapper;
        }

        public async Task<UserSettingsModel> SignIn(UserModel user)
        {
            UserEntity? userEntity;
            UserSettingsEntity? userSettingsEntity;

            if (!string.IsNullOrWhiteSpace(user.Settings.RefreshToken))
            {
                userSettingsEntity = await _unitOfWork.UserRepository.GetUserSettingsByRefreshToken(user.Settings.RefreshToken);
            }
            else
            {
                userEntity = _mapper.Map<UserEntity>(user);

                userEntity = await _unitOfWork.UserRepository.GetEntityByCredentials(userEntity);

                userSettingsEntity = await _unitOfWork.UserRepository.GetUserSettingsByUserId(userEntity.Id);
            }

            if (userSettingsEntity.AccessTokenExpireTime is null || userSettingsEntity.AccessTokenExpireTime < DateTime.UtcNow)
            {
                userSettingsEntity.AccessToken = AuthTokenModel.MakeAccessToken(user.Email);
                userSettingsEntity.AccessTokenExpireTime = DateTime.UtcNow.Add(TimeSpan.FromDays(0.5));
            }

            if (userSettingsEntity.RefreshTokenExpireTime is null || userSettingsEntity.RefreshTokenExpireTime < DateTime.UtcNow)
            {
                userSettingsEntity.RefreshToken = AuthTokenModel.MakeRefreshToken(user.Email);
                userSettingsEntity.RefreshTokenExpireTime = DateTime.UtcNow.Add(TimeSpan.FromDays(3));
            }

            UserSettingsEntity settingsEntity = _mapper.Map<UserSettingsEntity>(user.Settings);

            await _unitOfWork.UserRepository.UpdateUserSettings(settingsEntity);

            UserSettingsModel settingsModel = _mapper.Map<UserSettingsModel>(userSettingsEntity);

            return settingsModel;
        }

        public async Task<UserModel> SignUp(UserModel user)
        {
            UserEntity entity = _mapper.Map<UserEntity>(user);

            await _unitOfWork.UserRepository.AddEntity(entity);

            return _mapper.Map<UserModel>(entity);
        }

        public async Task<bool> ChangeSettings(UserSettingsModel settings)
        {
            try
            {
                UserSettingsEntity entity = _mapper.Map<UserSettingsEntity>(settings);

                await _unitOfWork.UserRepository.UpdateUserSettings(entity);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return false;
            }
        }
    }
}
