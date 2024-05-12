using System.Text.Json.Serialization;

namespace API.Models.DTO
{
    public class BaseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
