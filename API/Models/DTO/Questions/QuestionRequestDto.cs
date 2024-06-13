using API.Models.DTO.Answers;
using Newtonsoft.Json;

namespace API.Models.DTO.Questions
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
