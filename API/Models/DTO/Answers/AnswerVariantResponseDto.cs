using API.Models.DTO;
using Newtonsoft.Json;

namespace IKnowCoding.API.Models.DTO.Answers
{
    public class AnswerVariantResponseDto : BaseDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        public AnswerVariantResponseDto() { }
    }
}
