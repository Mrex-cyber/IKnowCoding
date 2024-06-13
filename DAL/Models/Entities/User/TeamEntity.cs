using DAL.Models.Entities.Relationships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.User
{
    [Table("obj_teams")]
    public class TeamEntity : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Admin))]
        [Column("user_id")]
        public int AdminId { get; set; }

        public TeamAdministrator Admin { get; set; } = null!;

        public ICollection<UserTeamConnectionEntity> Users { get; set; }
    }
}
