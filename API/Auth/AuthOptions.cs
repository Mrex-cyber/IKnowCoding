﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IKnowCoding.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "EnglishTesterServer";
        public const string AUDIENCE = "EnglishLearner";
        private const string KEY = "tester5erv3rtaskfortesting";
        public static SymmetricSecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
