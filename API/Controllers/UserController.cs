using API.Models.DTO.User;
using AutoMapper;
using EnglishTesterServer.DAL.UnitsOfWork;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Models.Models;
using IKnowCoding.DAL.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
namespace IKnowCoding.Controllers
{
    public class UserController : Controller
    {
        private UnitOfWorkPlatform _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
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

        /// <summary>
        /// Signing in
        /// </summary>
        /// <returns>User token and email</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST /api/user/signin
        ///     {
        ///         "firstName": null, 
        ///         "lastName": null, 
        ///         "email": "someemail@gmail.com", 
        ///         "password": "key12345"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200" link="">Returns tests for some user</response>
        /// <response code="204">The user was not found</response>
        /// <response code="400">Request is null</response>
        /// <response code="409">Email or password are incorrect</response>
        [HttpPost("/api/user/signin")]
        public async Task<IResult> SignIn([FromBody]DAL.Models.UserCredentialsModel credentials)
        {
            UserEntity user = _unitOfWork.UserRepository.GetModelByCredentials(credentials);

            UserSettingsDto userSettings = _mapper.Map<UserSettingsDto>(user);

            userSettings.IsAdmin = true;
            userSettings.Token = AuthTokenModel.MakeToken(userSettings.Email);

            return Results.Json(userSettings);
        }

        /// <summary>
        /// Registrating user
        /// </summary>
        /// <returns>Successfull message</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST /api/user/signup
        ///     {
        ///         "firstName": "Tom", 
        ///         "lastName": "Ford", 
        ///         "email": "someemail@gmail.com", 
        ///         "password": "key12345"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200" link="">Registered successfully</response>
        /// <response code="400">Request is null</response>
        /// <response code="409">Email or password are incorrect</response>
        [HttpPost("/api/user/signup")]
        public async Task<IResult> SignUp([FromBody] UserEntity userData)
        {
            bool result = _unitOfWork.UserRepository.AddEntity(userData);

            return Results.Json(result);
        }

    }
}
