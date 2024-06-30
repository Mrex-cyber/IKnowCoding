using Newtonsoft.Json;
using Shared.Models.DTO.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.DTO.Questions.Create
{
    public class BaseQuestionCreateDto
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "answers")]
        public AnswerVariantRequestDto[] Answers { get; set; }
    }
}
