namespace BLL.Models.Tests
{
    public class TestModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public string ImagePath { get; set; }
        public int Result { get; set; }
        public ICollection<QuestionModel> Questions { get; set; } = null!;
    }
}
