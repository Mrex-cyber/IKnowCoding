

using DAL.Models.Entities.MainPage;

namespace DAL.Repositories.MainPage
{
    public interface IMainPageRepository : IDisposable
    {
        IEnumerable<AchievementEntity> GetAchievements();
        IEnumerable<FeedbackEntity> GetFeedbacks();
    }
}