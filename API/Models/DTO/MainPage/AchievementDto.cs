using System.Text.Json.Serialization;

namespace API.Models.DTO.MainPage
{
    public class AchievementDto : BaseDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("imagePath")]
        public string ImagePath { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
}
