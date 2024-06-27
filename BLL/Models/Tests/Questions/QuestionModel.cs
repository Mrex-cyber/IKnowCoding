using BLL.Models.Tests.Answers;
using BLL.Models.Tests.Tests;

namespace BLL.Models.Tests.Questions
{
    public class QuestionModel : BaseModel
    {
        public string Text { get; set; }
        public TestBaseModel Test { get; set; } = null!;

        public ICollection<int> AnswerIds { get; set; } = new List<int>();
    }
}
