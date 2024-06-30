using Newtonsoft.Json;
using Shared.Models.DTO.Answers;

namespace Shared.Models.DTO.Questions
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
