using API.Models.DTO.Answers;
using Newtonsoft.Json;

namespace API.Models.DTO.Questions
{
    public class QuestionRequestDto : BaseDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "answers")]
        public AnswerVariantRequestDto[] Answers { get; set; }

        public QuestionRequestDto() { }
        public QuestionRequestDto(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
