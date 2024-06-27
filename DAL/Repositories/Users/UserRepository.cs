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

        public async Task<bool> AddEntity(UserEntity entity)
        {
            await _context.Users.AddAsync(entity);

            return true;
        }

        public async Task<IEnumerable<UserEntity>> GetEntities()
        {
            return _context.Users;
        }

        public async Task<UserEntity> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddSettings(UserSettingsEntity settings)
        {
            await _context.AddAsync(settings);

            Save();

            return true;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEntity(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserEntity>> GetTopTenUsers()
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

        public async Task<UserEntity> GetEntityByCredentials(UserEntity credentials)
        {
            UserEntity user = _context.Users
                .Where(u =>
                    u.Email == credentials.Email
                        && u.Password == credentials.Password)
                .Single();

            return user;
        }



        public async Task<UserSettingsEntity> GetUserSettingsByUserId(int userId)
        {
            UserSettingsEntity userSettingsEntity = _context.UserSettings.First(s => s.UserId == userId);

            return userSettingsEntity;
        }

        public async Task<UserSettingsEntity> GetUserSettingsByCredentials(string email, string password)
        {
            UserEntity user = await _context.Users.SingleAsync(u => u.Email == email && u.Password == password);

            UserSettingsEntity userSettingsEntity = _context.UserSettings.First(s => s.UserId == user.Id);

            return userSettingsEntity;
        }

        public async Task<UserSettingsEntity> GetUserSettingsByRefreshToken(string refreshToken)
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
    }
}
