using AutoMapper;
using DAL.Models.Entities.MainPage;
using DAL.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTO.MainPage;

namespace API.Controllers
{
    [ApiController]
    public class MainPageController : ControllerBase
    {
        private UnitOfWorkPlatform _unitOfWork;
        private readonly IMapper _mapper;

        public MainPageController(IUnitOfWork unitOfWork, IMapper mapper)
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

        /// <summary>
        /// Getting achievements
        /// </summary>
        /// <returns>Json list of achievements</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     GET /api/main/achievements
        ///     
        /// </remarks>
        /// <response code="200" link="">Returns achievements</response>
        [HttpGet("api/main/achievements")]
        public IResult OnGetAchievements()
        {
            return Results.Json(_unitOfWork.MainPageRepository.GetAchievements());
        }

        /// <summary>
        /// Getting feedbacks
        /// </summary>
        /// <returns>Json list of feedbacks</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     GET /api/main/feedbacks
        ///     
        /// </remarks>
        /// <response code="200" link="">Returns feedbacks</response>
        [HttpGet("api/main/feedbacks")]
        public async Task<IResult> OnGetFeedbacks()
        {
            IEnumerable<FeedbackEntity> feedbackEntities = _unitOfWork.MainPageRepository.GetFeedbacks();

            return Results.Json(_mapper.Map<FeedbackDto[]>(feedbackEntities));
        }
    }
}
