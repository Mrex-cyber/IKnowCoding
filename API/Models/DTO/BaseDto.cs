using Newtonsoft.Json;

namespace API.Models.DTO
{
    public class BaseDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}
