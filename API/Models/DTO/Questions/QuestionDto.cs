using IKnowCoding.API.Models.DTO.Answers;
using IKnowCoding.DAL.Models.Entities;
using Newtonsoft.Json;
using System.Data;

namespace IKnowCoding.API.Models.DTO.Questions
{
    public class QuestionDto
    {
        public QuestionDto() { }
        public QuestionDto(int id, string text)
        {
            Id = id;
            Text = text;
        }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "test")]
        public Tests.TestDto? Tests { get; set; }
        [JsonProperty(PropertyName = "answers")]
        public AnswerVariantDto[]? Answers { get; set; }
    }
}
