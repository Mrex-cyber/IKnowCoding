using DAL.Models;
using DAL.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Users
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private PlatformContext _context;
        public UserRepository(PlatformContext context)
        {
            _context = context;
        }

        public bool AddEntity(UserEntity entity)
        {
            _context.Users.Add(entity);

            return true;
        }

        public IEnumerable<UserEntity> GetEntities()
        {
            return _context.Users;
        }

        public UserEntity GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdatedEntity(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<UserEntity> GetTopTenUsers()
        {
            return _context.Users
                .GroupJoin(_context.UserTestResults,
                u => u.Id,
                r => r.UserId,
                (u, r) => new { User = u, Points = r.Sum(i => i.Result) }
                )
                .OrderByDescending(res => res.Points)
                .Select(res => res.User);
        }

        public UserEntity GetEntityByCredentials(UserCredentialsModel credentials)
        {
            UserEntity user = _context.Users
                .Where(u =>
                    u.Email == credentials.email
                        && u.Password == credentials.password)
                .Single();

            return user;
        }

        public UserSettingsEntity GetUserSettingsByUserId(int userId)
        {
            UserSettingsEntity userSettingsEntity = _context.UserSettings.First(u => u.UserId == userId);

            return userSettingsEntity;
        }

        public UserSettingsEntity GetUserSettingsByRefreshToken(string refreshToken)
        {
            UserSettingsEntity userSettingsEntity = _context.UserSettings
                .Include(s => s.User)
                .First(u => u.RefreshToken == refreshToken);

            return userSettingsEntity;
        }

        public async Task UpdateUserSettings(UserSettingsEntity userSettings)
        {
            _context.Attach(userSettings);
            _context.Update(userSettings);
        }
    }
}
