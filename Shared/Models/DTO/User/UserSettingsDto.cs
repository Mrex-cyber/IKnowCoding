using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models.DTO.User
{
    public record UserSettingsDto
    {
        [JsonProperty(PropertyName = "access_token")]
        public string? AccessToken { get; set; }

        [NotMapped]
        public DateTime? AccessTokenExpireTime { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string? RefreshToken { get; set; }

        [NotMapped]
        public DateTime? RefreshTokenExpireTime { get; set; }

        [JsonProperty(PropertyName = "isAdmin")]
        public bool IsAdmin { get; set; }
    }
}
