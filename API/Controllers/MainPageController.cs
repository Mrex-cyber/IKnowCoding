using AutoMapper;
using BLL.Models.MainPage;
using BLL.Services.MainPage;
using BLL.Services.Tests.TestsService.BaseTestsService;
using DAL.Models.Entities.MainPage;
using DAL.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTO.MainPage;

namespace API.Controllers
{
    [ApiController]
    public class MainPageController : ControllerBase
    {
        private IMainPageService _mainPageService;
        private readonly IMapper _mapper;

        public MainPageController(IMainPageService mainPageService, IMapper mapper)
        {
            _mainPageService = mainPageService;
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
        public async Task<IResult> OnGetAchievements()
        {
            IEnumerable<AchievementModel> models = await _mainPageService.GetAchievementsAsync();

            IEnumerable<AchievementDto> dtos = _mapper.Map<IEnumerable<AchievementDto>>(models);

            return Results.Json(dtos);
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
            IEnumerable<FeedbackModel> models = await _mainPageService.GetTopTenFeedbacksAsync();

            IEnumerable<FeedbackDto> dtos = _mapper.Map<FeedbackDto[]>(models);


            return Results.Json(dtos);
        }
    }
}
