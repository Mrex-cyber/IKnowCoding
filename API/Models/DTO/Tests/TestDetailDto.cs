using API.Models.DTO;
using IKnowCoding.API.Models.DTO.Questions;
using Newtonsoft.Json;

namespace IKnowCoding.API.Models.DTO.Tests
{
    public class TestDetailDto : BaseDto
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "questions")]
        public QuestionResponseDto[] Questions { get; set; }

        public TestDetailDto() { }
        public TestDetailDto(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
