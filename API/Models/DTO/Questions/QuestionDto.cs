using API.Models.DTO;
using IKnowCoding.API.Models.DTO.Answers;
using IKnowCoding.API.Models.DTO.Tests;
using Newtonsoft.Json;

namespace IKnowCoding.API.Models.DTO.Questions
{
    public class QuestionDto : BaseDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "answers")]
        public AnswerVariantDto[] Answers { get; set; }

        public QuestionDto() { }
        public QuestionDto(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
