using IKnowCoding.API.Models.DTO.Questions;
using Newtonsoft.Json;

namespace API.Models.DTO.User
{
    public class UserSettingsDto
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; } = "";

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; } = "";

        [JsonProperty(PropertyName = "isAdmin")]
        public bool IsAdmin { get; set; }
    }
}
