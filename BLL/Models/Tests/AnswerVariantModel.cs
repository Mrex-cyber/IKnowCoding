namespace BLL.Models.Tests
{
    public class AnswerVariantModel : BaseModel
    {
        public string Text { get; set; }
        public bool IsRight { get; set; }
        public QuestionModel Question { get; set; }
    }
}
