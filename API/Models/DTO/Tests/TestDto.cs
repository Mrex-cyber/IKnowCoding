using API.Models.DTO;
using IKnowCoding.API.Models.DTO.Questions;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IKnowCoding.API.Models.DTO.Tests
{
    public class TestDto : BaseDto
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "questions")]
        public QuestionDto[] Questions { get; set; }

        [JsonProperty(PropertyName = "result")]
        public int Result { get; set; }

        public TestDto() { }
        public TestDto(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
