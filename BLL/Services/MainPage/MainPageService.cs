using AutoMapper;
using BLL.Models.MainPage;
using DAL.Models.Entities.MainPage;
using DAL.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.MainPage
{
    public class MainPageService : IMainPageService
    {
        private UnitOfWorkPlatform _unitOfWork;
        private readonly IMapper _mapper;

        public MainPageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork is not null && unitOfWork is UnitOfWorkPlatform)
            {
                _unitOfWork = unitOfWork as UnitOfWorkPlatform;
            }
            else
            {
                _unitOfWork = new UnitOfWorkPlatform();
            }

            _mapper = mapper;
        }

        public async Task<IEnumerable<AchievementModel>> GetAchievementsAsync()
        {
            IEnumerable<AchievementEntity> entities = await _unitOfWork.MainPageRepository.GetAchievementsAsync();

            IEnumerable<AchievementModel> models = _mapper.Map<IEnumerable<AchievementModel>>(entities);

            return models;
        }

        public async Task<IEnumerable<FeedbackModel>> GetFeedbacksAsync()
        {
            IEnumerable<FeedbackEntity> entities = await _unitOfWork.MainPageRepository.GetFeedbacksAsync();

            IEnumerable<FeedbackModel> models = _mapper.Map<IEnumerable<FeedbackModel>>(entities);

            return models;
        }

        public async Task<IEnumerable<FeedbackModel>> GetTopTenFeedbacksAsync()
        {
            IEnumerable<FeedbackEntity> entities = await _unitOfWork.MainPageRepository.GetTopTenFeedbacksAsync();

            IEnumerable<FeedbackModel> models = _mapper.Map<IEnumerable<FeedbackModel>>(entities);

            return models;
        }
    }
}
