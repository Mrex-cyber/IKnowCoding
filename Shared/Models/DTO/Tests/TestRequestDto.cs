using Newtonsoft.Json;
using Shared.Models.DTO.Questions;

namespace Shared.Models.DTO.Tests
{
    public class TestRequestDto : BaseDto
    {
        [JsonProperty(PropertyName = "questions")]
        public QuestionRequestDto[] Questions { get; set; }

        public TestRequestDto() { }
        public TestRequestDto(int id)
        {
            Id = id;
        }
    }
}
