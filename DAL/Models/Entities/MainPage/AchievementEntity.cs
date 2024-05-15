using DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKnowCoding.DAL.Models.DTO.Main_Page
{
    public class AchievementEntity : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("image_path")]
        public string ImagePath { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("source")]
        public string Source { get; set; }

        public AchievementEntity() {
            Title = "None";
            ImagePath = "None";
            Text = "None";
            Source = "None";
        }

        public AchievementEntity(int id, string title, string imagePath, string text, string source)
        {
            Id = id;
            Title = title;
            ImagePath = imagePath;
            Text = text;
            Date = DateTime.UtcNow;
            Source = source;
        }
    }
}
