using BLL.Models.MainPage;
using BLL.Models.Teams.Relationships;
using BLL.Models.User.Relationships;

namespace BLL.Models.User
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int FeedbackId { get; set; }
        public int SettingsId { get; set; }
        public ICollection<int>? TestResultEntities { get; set; } = new List<int>();
        public ICollection<int>? Teams { get; set; } = new List<int>();
    }
}
