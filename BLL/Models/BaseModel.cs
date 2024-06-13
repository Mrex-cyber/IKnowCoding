using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    public class BaseModel
    {
        [Required]
        [Column("id")]
        [Key]
        public int Id { get; set; }

        public BaseModel(int id = 0)
        {
            Id = id;
        }
    }
}
