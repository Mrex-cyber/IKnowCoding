using BLL.Models.MainPage;
using BLL.Models.Relationships;

namespace BLL.Models.User
{
    public class UserModel : PersonModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public FeedbackModel Feedback { get; set; }
        public UserSettingsModel Settings { get; set; }
        public ICollection<UserTestResultModel> TestResultEntities { get; set; }
        public ICollection<UserTeamConnectionEntity> Teams { get; set; }
    }
}
