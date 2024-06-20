using BLL.Models.MainPage;
using BLL.Models.Teams.Relationships;
using BLL.Models.User.Relationships;

namespace BLL.Models.User
{
    public class UserModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public FeedbackModel? Feedback { get; set; }
        public UserSettingsModel Settings { get; set; }
        public ICollection<UserTestResultModel>? TestResultEntities { get; set; }
        public ICollection<UserTeamConnectionEntity>? Teams { get; set; }
    }
}
