using EnglishTesterServer.DAL.UnitsOfWork;
using Google.Apis.Auth.OAuth2;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace IKnowCoding.Controllers
{
    public class UserController : Controller
    {
        private UnitOfWorkPlatform unitOfWork = new UnitOfWorkPlatform();

        public UserController() { }

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
            UserEntity user = unitOfWork.UserRepository.GetModelByCredentials(credentials);

            return Results.Json(user);
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
        public async Task<IResult> SignInGoogle([FromBody]DAL.Models.UserCredentialsModel credentials)
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
        public async Task<IResult> SignUp([FromBody] UserEntity userData)
        {
            bool result = unitOfWork.UserRepository.AddEntity(userData);

            return Results.Json(result);
        }

    }
}
