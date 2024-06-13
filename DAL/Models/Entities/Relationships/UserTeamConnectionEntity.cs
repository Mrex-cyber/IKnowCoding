using DAL.Models.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.Relationships
{
    [Table("rel_users_teams")]
    public class UserTeamConnectionEntity : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Team))]
        [Column("team_id")]
        public int TeamId { get; set; }

        public TeamEntity Team { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public int UserId { get; set; }

        public UserEntity User { get; set; } = null!;
    }
}
