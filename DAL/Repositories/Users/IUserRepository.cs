using DAL.Models.Entities.User;

namespace DAL.Repositories.Users
{
    public interface IUserRepository : ICrud<UserEntity>, IDisposable
    {
        Task<UserEntity> GetEntityByCredentials(UserEntity credentials);
    }
}
