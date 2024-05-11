using IKnowCoding.API.Models.DTO.Questions;
using IKnowCoding.DAL.Models.Entities;
using Newtonsoft.Json;
using System.Data;

namespace IKnowCoding.API.Models.DTO.Tests
{
    public class TestDetailDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "questions")]
        public QuestionDto[] Questions { get; set; }

        public TestDetailDto() { }
        public TestDetailDto(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
