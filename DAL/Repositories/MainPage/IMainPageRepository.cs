

using IKnowCoding.API.Models.DTO.MainPage;
using IKnowCoding.DAL.Models.DTO.Main_Page;

namespace IKnowCoding.DAL.Repositories.MainPage
{
    public interface IMainPageRepository : IDisposable
    {
        IEnumerable<AchievementEntity> GetAchievements();
        IEnumerable<FeedbackEntity> GetFeedbacks();
    }
}