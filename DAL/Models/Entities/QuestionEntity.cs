using DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace IKnowCoding.DAL.Models.Entities
{
    [Table("Questions")]
    public class QuestionEntity : BaseEntity
    {
        [Column("text")]
        public string Text { get; set; }

        [ForeignKey(nameof(Test))]
        [Column("test_id")]
        public int TestId { get; set; }
        public TestEntity Test { get; set; } = null!;

        public ICollection<AnswerVariantEntity> Answers { get; set; } = null!;

        public QuestionEntity() {
            Text = "None";
        }
        public QuestionEntity(int id, int testId, string text)
        {
            Id = id;
            TestId = testId;
            Text = text;
        }
    }
}
