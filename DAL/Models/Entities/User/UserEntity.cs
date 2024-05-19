using DAL.Models;
using IKnowCoding.API.Models.DTO.MainPage;
using IKnowCoding.DAL.Models.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace DAL.Models.Entities.User
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [Column("firstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("lastName")]
        public string LastName { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [ForeignKey(nameof(Feedback))]
        [Column("feedback_id")]
        public int FeedbackId { get; set; }
        public FeedbackEntity Feedback { get; set; } = null!;

        [ForeignKey(nameof(UserSettings))]
        [Column("user_settings_id")]
        public int UserSettingsId { get; set; }
        public UserSettingsEntity UserSettings { get; set; } = null!;

        public List<UserTestResultEntity> TestResultEntities { get; set; } = null!;

        public UserEntity()
        {
            FirstName = "Anonimous";
            LastName = "Anonimous";
            Email = "None";
            Password = "None";
        }
        public UserEntity(int id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
