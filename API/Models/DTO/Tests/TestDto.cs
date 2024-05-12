using API.Models.DTO;
using Newtonsoft.Json;

namespace IKnowCoding.API.Models.DTO.Tests
{
    public class TestDto : BaseDto
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        public TestDto() { }
        public TestDto(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
