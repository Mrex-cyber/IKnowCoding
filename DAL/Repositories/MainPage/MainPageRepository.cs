using DAL.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.MainPage
{
    public class MainPageRepository : IMainPageRepository, IDisposable
    {
        private PlatformContext _context;

        public MainPageRepository(PlatformContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AchievementEntity>> GetAchievementsAsync()
        {
            return _context.Achievements;
        }

        public async Task<IEnumerable<FeedbackEntity>> GetFeedbacksAsync()
        {
            return _context.Feedbacks
                .Include(f => f.User)
                    .ThenInclude(u => u.Person)
                .AsEnumerable();
        }

        public async Task<IEnumerable<FeedbackEntity>> GetTopTenFeedbacksAsync()
        {
            return _context.Feedbacks
                .Include(f => f.User)
                    .ThenInclude(u => u.Person)
                .Take(10)
                .AsEnumerable();
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
