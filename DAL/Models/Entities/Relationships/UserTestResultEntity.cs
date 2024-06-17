using DAL.Models.Entities.Tests;
using DAL.Models.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.Relationships
{
    [Table("rel_user_test_results")]
    public class UserTestResultEntity : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public int UserId { get; set; }

        public UserEntity User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Test))]
        [Column("test_id")]
        public int TestId { get; set; }

        public TestEntity Test { get; set; } = null!;

        [Column("finished")]
        public bool Finished { get; set; }

        [Required]
        [Column("access_time")]
        public DateTime AccessTime { get; set; }

        [Column("finished_time")]
        public DateTime? FinishedTime { get; set; }

        [Column("result")]
        public int Result { get; set; }

        public UserTestResultEntity(int id, int userId, int testId) : base(id)
        {
            UserId = userId;
            TestId = testId;
            AccessTime = DateTime.UtcNow;
            FinishedTime = DateTime.UtcNow;
            Result = 0;
        }
    }
}
