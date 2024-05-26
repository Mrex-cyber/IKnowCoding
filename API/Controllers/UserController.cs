using EnglishTesterServer.DAL.UnitsOfWork;
using Google.Apis.Auth.OAuth2;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
﻿using API.Models.DTO.User;
using AutoMapper;
using DAL.Models.Entities.User;
using EnglishTesterServer.DAL.UnitsOfWork;
using IKnowCoding.API.Models.DTO.Tests;
using IKnowCoding.DAL.Models.Models;
using IKnowCoding.DAL.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            UserEntity? userEntity;
            UserSettingsEntity? userSettingsEntity;

            if (!string.IsNullOrWhiteSpace(Request.Headers["refresh_token"]))
            {
                userSettingsEntity = _unitOfWork.UserRepository.GetUserSettingsByRefreshToken(Request.Headers["refresh_token"]!);
            }
            else
            {
                userEntity = _unitOfWork.UserRepository.GetEntityByCredentials(credentials);

                userSettingsEntity = _unitOfWork.UserRepository.GetUserSettingsByUserId(userEntity.Id);
            }

            if (userSettingsEntity.AccessTokenExpireTime is null || userSettingsEntity.AccessTokenExpireTime < DateTime.UtcNow)
            {
                userSettingsEntity.AccessToken = AuthTokenModel.MakeAccessToken(credentials.email);
                userSettingsEntity.AccessTokenExpireTime = DateTime.UtcNow.Add(TimeSpan.FromDays(0.5));
            }

            if (userSettingsEntity.RefreshTokenExpireTime is null || userSettingsEntity.RefreshTokenExpireTime < DateTime.UtcNow)
            {
                userSettingsEntity.RefreshToken = AuthTokenModel.MakeRefreshToken(credentials.email);
                userSettingsEntity.RefreshTokenExpireTime = DateTime.UtcNow.Add(TimeSpan.FromDays(3));
            }

            await _unitOfWork.UserRepository.UpdateUserSettings(userSettingsEntity);

            UserSettingsDto userSettingsDto = _mapper.Map<UserSettingsDto>(userSettingsEntity);

            string json = JsonConvert.SerializeObject(_mapper.Map<UserSettingsDto>(userSettingsDto), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return Results.Text(json, "text/plain");
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
            bool result = _unitOfWork.UserRepository.AddEntity(userData);

            return Results.Json(result);
        }

    }
}
