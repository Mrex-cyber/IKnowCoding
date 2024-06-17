using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.User
{
    [Table("obj_people")]
    public class PersonEntity : BaseEntity
    {
        [Required]
        [Column("firstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("lastName")]
        public string LastName { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public int UserId { get; set; }

        public UserEntity User { get; set; } = null!;

        public PersonEntity(int id, string firstName, string lastName, int userId) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
        }
    }
}
