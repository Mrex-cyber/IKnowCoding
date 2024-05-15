using DAL.Models;
using IKnowCoding.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKnowCoding.API.Models.DTO.MainPage
{
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

        public FeedbackEntity() {
            Text = "None";
            ImagePath = "None";
        }

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
