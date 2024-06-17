using DAL.Models.Entities.MainPage;
using DAL.Models.Entities.Relationships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.User
{
    [Table("obj_users")]
    public class UserEntity : BaseEntity
    {
        [Required]
        [Column("email")]
        public string Email { get; set; } = null!;

        [Required]
        [Column("password")]
        public string Password { get; set; } = null!;

        [ForeignKey(nameof(Feedback))]
        [Column("feedback_id")]
        public int FeedbackId { get; set; }
        public FeedbackEntity Feedback { get; set; } = null!;

        [ForeignKey(nameof(Settings))]
        [Column("settings_id")]
        public int SettingsId { get; set; }
        public UserSettingsEntity Settings { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Person))]
        [Column("person_id")]
        public int PersonId { get; set; }

        public PersonEntity Person { get; set; } = null!;

        public ICollection<UserTestResultEntity> TestResultEntities { get; set; } = null!;

        public ICollection<UserTeamConnectionEntity> Teams { get; set; } = null!;

        public UserEntity(int id, string email, string password, int feedbackId, int settingsId, int personId)
            : base(id)
        {
            Email = email;
            Password = password;
            FeedbackId = feedbackId;
            SettingsId = settingsId;
            PersonId = personId;
        }
    }
}
