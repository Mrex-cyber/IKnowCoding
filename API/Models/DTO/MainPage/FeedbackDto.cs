using API.Models.DTO;
using IKnowCoding.DAL.Models.DTO.Main_Page;
using System.Text.Json.Serialization;

namespace IKnowCoding.API.Models.DTO.MainPage
{
    public class FeedbackDto : BaseDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("imagePath")]
        public string ImagePath { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
    }
}
