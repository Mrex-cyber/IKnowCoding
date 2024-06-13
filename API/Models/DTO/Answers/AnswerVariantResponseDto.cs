using Newtonsoft.Json;

namespace API.Models.DTO.Answers
{
    public class AnswerVariantResponseDto : BaseDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        public AnswerVariantResponseDto() { }
    }
}
