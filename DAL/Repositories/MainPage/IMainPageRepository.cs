

using DAL.Models.Entities.MainPage;

namespace DAL.Repositories.MainPage
{
    public interface IMainPageRepository : IDisposable
    {
        Task<IEnumerable<AchievementEntity>> GetAchievementsAsync();
        Task<IEnumerable<FeedbackEntity>> GetFeedbacksAsync();
    }
}