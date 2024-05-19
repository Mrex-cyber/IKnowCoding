using DAL.Models.Entities.User;
using IKnowCoding.DAL.Models;

namespace IKnowCoding.DAL.Repositories.Users
{
    public interface IUserRepository : ICrud<UserEntity>, IDisposable
    {
        UserEntity GetEntityByCredentials(UserCredentialsModel credentials);
    }
}
