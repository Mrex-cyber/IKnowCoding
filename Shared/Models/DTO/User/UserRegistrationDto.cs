using Newtonsoft.Json;

namespace Shared.Models.DTO.User
{
    public record UserRegistrationDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string? FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string? LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; } = null!;

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; } = null!;
    };
}
