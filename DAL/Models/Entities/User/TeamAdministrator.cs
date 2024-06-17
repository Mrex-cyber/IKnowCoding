using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Entities.Teams;

namespace DAL.Models.Entities.User
{
    [Table("obj_team_admins")]
    public class TeamAdministrator : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public int UserId { get; set; }

        public UserEntity User { get; set; } = null!;

        public ICollection<TeamEntity> Teams { get; set; }

        public TeamAdministrator(int id, int userId) : base(id)
        {
            UserId = userId;
        }
    }
}
