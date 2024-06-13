using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "IKnowCodingIssuer";
        public const string AUDIENCE = "WeKnowCoding";
        private const string KEY = "tester5erv3rtaskfortestingIKnowCoding";
        public static SymmetricSecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
