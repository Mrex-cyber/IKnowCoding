using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace API.Models.DTO
{
    public class BaseDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}
