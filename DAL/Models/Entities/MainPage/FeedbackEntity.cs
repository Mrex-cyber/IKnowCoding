using DAL.Models.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.MainPage
{
    [Table("obj_feedbacks")]
    public class FeedbackEntity : BaseEntity
    {
        [Column("text")]
        public string Text { get; set; }

        [Column("image_path")]
        public string ImagePath { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public FeedbackEntity(int id, string text, string imagePath, int userId)
        {
            Id = id;
            Text = text;
            ImagePath = imagePath;
            Date = DateTime.UtcNow;
            UserId = userId;
        }
    }
}
