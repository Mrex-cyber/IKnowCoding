using BLL.Models.Tests.Questions;

namespace BLL.Models.Tests.Answers
{
    public class AnswerVariantModel : BaseModel
    {
        public string Text { get; set; }
        public bool IsRight { get; set; }
        public QuestionModel Question { get; set; }
    }
}
