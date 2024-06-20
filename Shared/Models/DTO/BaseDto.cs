using Newtonsoft.Json;

namespace Shared.Models.DTO
{
    public class BaseDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}
