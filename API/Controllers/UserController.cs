using AutoMapper;
using BLL.Models.User;
using BLL.Services.Users.Settings;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTO.User;

namespace API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Signing in
        /// </summary>
        /// <returns>User token and email</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     GET /api/user/signin
        ///     Header:
        ///     {
        ///         "email": "someemail@gmail.com", 
        ///         "password": "key12345"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200" link="">Returns user settings saved in the DB</response>
        /// <response code="204">The user was not found</response>
        /// <response code="400">Request is null</response>
        /// <response code="409">Email or password are incorrect</response>
        [HttpGet("/api/user/signin")]
        public async Task<IResult> SignIn([FromHeader] UserLoginDto login, [FromHeader] UserSettingsDto settings)
        {
            UserModel user = _mapper.Map<UserModel>(login);

            user.Settings = _mapper.Map<UserSettingsModel>(settings);

            UserSettingsModel serviceResult = await _userService.SignIn(user);

            settings = _mapper.Map<UserSettingsDto>(serviceResult);

            return Results.Json(settings);
        }

        /// <summary>
        /// Signing in with Google
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
        [HttpPost("/api/user/signin-google")]
        public async Task<IResult> SignInGoogle([FromBody] DAL.Models.UserCredentialsModel credentials)
        {
            //var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //var claims = result.Principal.Identities.FirstOrDefault().Claims.Select;

            return Results.Ok();
            //return Results.Json(user);
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
        public async Task<IResult> SignUp([FromBody] UserRegistrationDto user)
        {
            UserModel userModel = _mapper.Map<UserModel>(user);

            userModel = await _userService.SignUp(userModel);

            return Results.Json(userModel);
        }


        /// <summary>
        /// Change user settings
        /// </summary>
        /// <returns>Successfull message</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST /api/user/signup
        ///     {
        ///         "accessToken": "XXXXXXXXXXXXXXXXXXXX", 
        ///         "accessTokenExpireTime": "10/02/2024", 
        ///         "refreshToken": "XXXXXXXXXXXXXXXXXXXX", 
        ///         "refreshTokenExpireTime": "15/07/2024"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200" link="">Settings changed successfully</response>
        /// <response code="400">Request body is incorrect</response>
        [HttpPut("/api/user/signup")]
        public async Task<IResult> ChangeSettigns([FromBody] UserSettingsDto settigns)
        {
            UserSettingsModel userSettigns = _mapper.Map<UserSettingsModel>(settigns);

            bool operationResult = await _userService.ChangeSettings(userSettigns);

            return operationResult
                ? Results.Ok("Settings changed successfully!")
                : Results.BadRequest("Something went wrong");
        }
    }
}
