using BLL.Models.Tests.Tests;

namespace BLL.Models.User.Relationships
{
    public class UserTestResultModel : BaseModel
    {
        public UserModel User { get; set; } = null!;
        public TestBaseModel Test { get; set; } = null!;
        public bool Finished { get; set; }
        public DateTime AccessTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        public int Result { get; set; }
    }
}
