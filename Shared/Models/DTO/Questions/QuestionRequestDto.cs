using Newtonsoft.Json;
using Shared.Models.DTO.Answers;

namespace Shared.Models.DTO.Questions
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
