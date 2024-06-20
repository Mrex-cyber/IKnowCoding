using BLL.Models.Tests.Questions;

namespace BLL.Models.Tests.Tests
{
    public class TestBaseModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public string ImagePath { get; set; }
        public int Result { get; set; }
        public ICollection<QuestionModel> Questions { get; set; } = null!;
    }
}
