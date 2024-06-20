using Newtonsoft.Json;

namespace Shared.Models.DTO.Answers
{
    public class AnswerVariantResponseDto : BaseDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        public AnswerVariantResponseDto() { }
    }
}
