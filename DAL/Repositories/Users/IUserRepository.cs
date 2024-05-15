using IKnowCoding.DAL.Models;
using IKnowCoding.DAL.Models.Entities;

namespace IKnowCoding.DAL.Repositories.Users
{
    public interface IUserRepository : ICrud<UserEntity>, IDisposable
    {
        UserEntity GetModelByCredentials(UserCredentialsModel credentials);
    }
}
