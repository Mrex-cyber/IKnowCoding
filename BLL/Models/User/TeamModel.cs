using BLL.Models.Relationships;

namespace BLL.Models.User
{
    public class TeamModel : BaseModel
    {
        public string Title { get; set; }
        public TeamAdministratorModel Admin { get; set; }
        public ICollection<UserTeamConnectionEntity> Users { get; set; }
    }
}
