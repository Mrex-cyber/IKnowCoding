using DAL.Models.Entities.Relationships;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.Tests
{
    [Table("obj_tests")]
    public class TestEntity : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_free")]
        public bool IsFree { get; set; }

        [Column("image_path")]
        public string ImagePath { get; set; }

        public ICollection<UserTestResultEntity> TestResultEntities { get; set; } = null!;

        public ICollection<QuestionEntity> Questions { get; set; } = null!;

        public TestEntity(int id, string title, string description, bool isFree, string imagePath)
        {
            Id = id;
            Title = title;
            Description = description;
            IsFree = isFree;
            ImagePath = imagePath;
        }
    }
}
