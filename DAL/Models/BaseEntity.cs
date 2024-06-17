using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class BaseEntity
    {
        [Required]
        [Column("id")]
        [Key]
        public int Id { get; set; }

        public BaseEntity(int id = 0)
        {
            Id = id;
        }
    }
}
