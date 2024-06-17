using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.Tests
{
    [Table("obj_answers")]
    public class AnswerVariantEntity : BaseEntity
    {

        [Column("text")]
        public string Text { get; set; }

        [Column("is_right")]
        public bool IsRight { get; set; }

        [ForeignKey(nameof(Question))]
        [Column("question_id")]
        public int QuestionId { get; set; }

        public QuestionEntity Question { get; set; } = null!;

        public AnswerVariantEntity()
        {
            Text = "None";
        }

        public AnswerVariantEntity(int id, int questionId, string text, bool isRight)
        {
            Id = id;
            QuestionId = questionId;
            Text = text;
            IsRight = isRight;
        }
    }
}
