using Newtonsoft.Json;

namespace Shared.Models.DTO.Answers
{
    public class AnswerVariantRequestDto : BaseDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "isRight")]
        public bool IsRight { get; set; }

        public AnswerVariantRequestDto() { }
    }
}
