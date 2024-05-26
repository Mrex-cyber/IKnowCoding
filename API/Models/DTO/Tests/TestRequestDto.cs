using API.Models.DTO;
using IKnowCoding.API.Models.DTO.Questions;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IKnowCoding.API.Models.DTO.Tests
{
    public class TestRequestDto : BaseDto
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "questions")]
        public QuestionRequestDto[] Questions { get; set; }

        [JsonProperty(PropertyName = "imagePath")]
        public string ImagePath { get; set; }

        public TestRequestDto() { }
        public TestRequestDto(int id, string title, string description, string imagePath)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
