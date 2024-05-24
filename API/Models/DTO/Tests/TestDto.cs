using API.Models.DTO;
using IKnowCoding.API.Models.DTO.Questions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace IKnowCoding.API.Models.DTO.Tests
{
    public class TestDto : BaseDto
    {
        [Required]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [AllowNull]
        [JsonProperty(PropertyName = "questions")]
        public QuestionDto[] Questions { get; set; }

        [JsonProperty(PropertyName = "result")]
        public int Result { get; set; }

        [JsonProperty(PropertyName = "imagePath")]
        public string ImagePath { get; set; }

        public TestDto() { }
        public TestDto(int id, string title, string description, string imagePath)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
