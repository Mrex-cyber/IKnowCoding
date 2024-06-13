using BLL.Models.Tests;
using BLL.Models.User;

namespace BLL.Models.Relationships
{
    public class UserTestResultModel : BaseModel
    {
        public UserModel User { get; set; } = null!;
        public TestModel Test { get; set; } = null!;
        public bool Finished { get; set; }
        public DateTime AccessTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        public int Result { get; set; }
    }
}
