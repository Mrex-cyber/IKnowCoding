using BLL.Models.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.MainPage
{
    public interface IMainPageService
    {
        Task<IEnumerable<AchievementModel>> GetAchievementsAsync();
        Task<IEnumerable<FeedbackModel>> GetFeedbacksAsync();
        Task<IEnumerable<FeedbackModel>> GetTopTenFeedbacksAsync();
    }
}
