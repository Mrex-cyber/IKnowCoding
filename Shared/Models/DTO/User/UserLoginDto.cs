using Newtonsoft.Json;

namespace Shared.Models.DTO.User
{
    public record UserLoginDto
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; } = null!;

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; } = null!;
    }
}
