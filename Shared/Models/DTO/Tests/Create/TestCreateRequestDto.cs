using Newtonsoft.Json;
using Shared.Models.DTO.Questions;
using Shared.Models.DTO.Questions.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.DTO.Tests.Create
{
    public class TestCreateRequestDto : BaseDto
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "imagePath")]
        public string ImagePath { get; set; }

        [JsonProperty(PropertyName = "isFree")]
        public bool IsFree { get; set; }

        [JsonProperty(PropertyName = "questions")]
        public BaseQuestionCreateDto[] Questions { get; set; }

        public TestCreateRequestDto() { }
        public TestCreateRequestDto(int id, string title, string description, string imagePath)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
