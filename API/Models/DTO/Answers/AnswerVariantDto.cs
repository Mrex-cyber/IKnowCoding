using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace IKnowCoding.API.Models.DTO.Answers
{
    public class AnswerVariantDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "text")]
        public string? Text { get; set; }


        [JsonProperty(PropertyName = "questionId")]
        [NotMapped]
        public int QuestionId { get; set; }
        public AnswerVariantDto() { }
    }
}
