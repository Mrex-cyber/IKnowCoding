using DAL.Models;
using DAL.Models.Entities.User;

namespace DAL.Repositories.Users
{
    public interface IUserRepository : ICrud<UserEntity>, IDisposable
    {
        UserEntity GetEntityByCredentials(UserCredentialsModel credentials);
    }
}
