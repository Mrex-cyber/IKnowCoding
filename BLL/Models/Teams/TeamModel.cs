using BLL.Models.Teams.Relationships;
using BLL.Models.User;

namespace BLL.Models.Teams
{
    public class TeamModel : BaseModel
    {
        public string Title { get; set; }
        public TeamAdministratorModel Admin { get; set; }
        public ICollection<UserTeamConnectionEntity> Users { get; set; }
    }
}
