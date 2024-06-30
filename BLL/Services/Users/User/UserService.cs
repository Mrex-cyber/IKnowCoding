using API.Auth;
using AutoMapper;
using BLL.Models.User;
using DAL.Models.Entities.User;
using DAL.Repositories.Users;
using DAL.UnitsOfWork;
using Microsoft.Extensions.Logging;
using Shared.Models.DTO.User;

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
            Console.WriteLine(user.FirstName + " " + user.LastName);
            UserSettingsEntity userSettingsEntity = await _unitOfWork.UserRepository.GetUserSettingsByCredentials(user.Email, user.Password);

            if (!string.IsNullOrWhiteSpace(userSettingsEntity.RefreshToken))
            {
                userSettingsEntity = await _unitOfWork.UserRepository.GetUserSettingsByRefreshToken(userSettingsEntity.RefreshToken);
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

            await _unitOfWork.UserRepository.UpdateUserSettings(userSettingsEntity);
            Console.WriteLine(userSettingsEntity.AccessToken);
            UserSettingsModel settingsModel = _mapper.Map<UserSettingsModel>(userSettingsEntity);

            return settingsModel;
        }

        public async Task<UserModel> SignUp(UserModel user)
        {
            UserEntity entity = _mapper.Map<UserEntity>(user);

            await _unitOfWork.UserRepository.AddEntity(entity);

            await _unitOfWork.UserRepository.AddSettings(entity.Settings);

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
