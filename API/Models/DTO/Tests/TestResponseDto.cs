using API.Models.DTO.Questions;
using Newtonsoft.Json;

namespace API.Models.DTO.Tests
{
    public class TestResponseDto : BaseDto
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "questions")]
        public QuestionResponseDto[] Questions { get; set; }

        [JsonProperty(PropertyName = "result")]
        public int Result { get; set; }

        [JsonProperty(PropertyName = "imagePath")]
        public string ImagePath { get; set; }

        public TestResponseDto() { }
        public TestResponseDto(int id, string title, string description, string imagePath)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
