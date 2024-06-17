namespace BLL.Models.User
{
    public class TeamAdministratorModel : UserModel
    {
        public ICollection<TeamModel> Teams { get; set; }
    }
}
