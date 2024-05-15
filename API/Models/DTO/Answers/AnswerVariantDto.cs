using API.Models.DTO;
using Newtonsoft.Json;

namespace IKnowCoding.API.Models.DTO.Answers
{
    public class AnswerVariantDto : BaseDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        public AnswerVariantDto() { }
    }
}
