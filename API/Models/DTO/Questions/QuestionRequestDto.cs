using API.Models.DTO;
using IKnowCoding.API.Models.DTO.Answers;
using IKnowCoding.API.Models.DTO.Tests;
using Newtonsoft.Json;

namespace IKnowCoding.API.Models.DTO.Questions
{
    public class QuestionResponseDto : BaseDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "answers")]
        public AnswerVariantResponseDto[] Answers { get; set; }

        public QuestionResponseDto() { }
        public QuestionResponseDto(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
