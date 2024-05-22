using IKnowCoding.API.Models.DTO.MainPage;
using IKnowCoding.DAL.Models.DTO.Main_Page;
using IKnowCoding.DAL.Repositories.MainPage;
using Microsoft.EntityFrameworkCore;

namespace IKnowCoding.DAL.Repositories.MainPage
{
    public class MainPageRepository : IMainPageRepository, IDisposable
    {
        private PlatformContext _context;
        public MainPageRepository(PlatformContext context)
        {
            _context = context;
        }
        public IEnumerable<AchievementEntity> GetAchievements()
        {
            return _context.Achievements;
        }
        public IEnumerable<FeedbackEntity> GetFeedbacks()
        {
            return _context.Feedbacks
                .Include(f => f.User)
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
