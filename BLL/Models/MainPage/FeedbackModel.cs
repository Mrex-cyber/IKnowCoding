using BLL.Models.User;

namespace BLL.Models.MainPage
{
    public class FeedbackModel : BaseModel
    {
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
