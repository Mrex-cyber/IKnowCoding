﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entities.Tests
{
    [Table("obj_questions")]
    public class QuestionEntity : BaseEntity
    {
        [Column("text")]
        public string Text { get; set; }

        [ForeignKey(nameof(Test))]
        [Column("test_id")]
        public int TestId { get; set; }
        public TestEntity Test { get; set; } = null!;

        public ICollection<AnswerVariantEntity> Answers { get; set; } = null!;

        public QuestionEntity(int id, int testId, string text)
            : base(id)
        {
            TestId = testId;
            Text = text;
        }
    }
}