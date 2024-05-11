using DAL.Models;
using IKnowCoding.DAL.Models.Entities.Relationships;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace IKnowCoding.DAL.Models.Entities
{
    public class TestEntity : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_free")]
        public bool IsFree { get; set; }

        public List<UserTestResultEntity> TestResultEntities { get; set; } = null!;

        public ICollection<QuestionEntity> Questions { get; set; } = null!;

        public TestEntity() {
            Title = "None";
            Description = "None";
        }
        public TestEntity(int id, string title, string description, bool isFree)
        {
            Id = id;
            Title = title;
            Description = description;
            IsFree = isFree;
        }
    }
}
