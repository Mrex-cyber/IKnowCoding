using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class BaseEntity
    {
        [Required]
        [Column("id")]
        [Key]
        public int Id { get; set; }
    }
}
