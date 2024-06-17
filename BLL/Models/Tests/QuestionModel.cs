namespace BLL.Models.Tests
{
    public class QuestionModel : BaseModel
    {
        public string Text { get; set; }
        public int TestId { get; set; }
        public TestModel Test { get; set; } = null!;

        public ICollection<AnswerVariantModel> Answers { get; set; } = null!;
    }
}
