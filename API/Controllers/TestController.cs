using API.Application.Filters;
using AutoMapper;
using BLL.Models.Tests.Tests;
using BLL.Services.Tests.TestsService.BaseTestsService;
using DAL.Models.Entities.Relationships;
using DAL.Models.Entities.Tests;
using DAL.Repositories.Tests;
using DAL.UnitsOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Models.DTO.Tests;

namespace API.Controllers
{
    [Authorize]
    [ValidateModel]
    public class TestController : Controller
    {
        private IBaseTestService _baseTestService;
        private readonly IMapper _mapper;

        public TestController(IBaseTestService baseTestService, IMapper mapper)
        {
            _baseTestService = baseTestService;
            _mapper = mapper;
        }

        /// <summary>
        /// Getting all free tests
        /// </summary>
        /// <returns>Json list of tests with questions and answers (without right answer)</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     GET /api/tests
        ///     
        /// </remarks>
        /// <response code="200" link="">Returns tests</response>
        /// <response code="204">If the test list is empty</response>
        [HttpGet("/api/tests")]
        [AllowAnonymous]
        public async Task<IResult> OnGetTests()
        {
            var commonTests = await _baseTestService.GetAllFreeTests();

            if (commonTests.Count() == 0)
            {
                return Results.NoContent();
            }

            string json = JsonConvert.SerializeObject(_mapper.Map<TestResponseDto[]>(commonTests), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return Results.Text(json, "text/plain");
        }
        /// <summary>
        /// Getting tests that are allowed to user with this email
        /// </summary>
        /// <returns>Json list of tests with questions and answers (without right answer)</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST /api/tests
        ///     {
        ///         "someemail@gmail.com"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200" link="">Returns tests for some user</response>
        /// <response code="204">If the test list is empty</response>
        [HttpPost("/api/tests")]
        public async Task<IResult> OnGetUserTests([FromHeader]int userId)
        {
            var userTests = await _baseTestService.GetAllUserAccessedTests(userId);

            if (userTests.Count() == 0)
            {
                return Results.NoContent();
            }

            string json = JsonConvert.SerializeObject(_mapper.Map<TestResponseDto[]>(userTests), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return Results.Text(json, "text/plain");
        }

        /// <summary>
        /// Getting test by ID
        /// </summary>
        /// <returns>Test with questions and answers (without right answer)</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     GET /api/tests/{testId}
        ///     
        /// </remarks>
        /// <response code="200" link="">Returns test</response>
        /// <response code="204">If the test not found</response>
        [HttpGet("/api/tests/{testId}")]
        public IResult OnGetTestById(int testId)
        {
            var test = _baseTestService.GetTestById(testId);

            if (test is null)
            {
                return Results.NoContent();
            }

            return Results.Json(test);
        }

        /// <summary>
        /// Checking the test
        /// </summary>
        /// <returns>Result (in points) for test</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST /api/tests/check
        ///     {
        ///         "userEmail": "someemail@gmail.com",
        ///         "testId": 1,
        ///         "answers": [
        ///             {
        ///                 "id": 1,
        ///                 "text": "How are you?",
        ///                 "questionId": 2
        ///             }
        ///         ]
        ///     }
        ///     
        /// </remarks>
        /// <response code="200" link="">Returns result (number)</response>
        [AllowAnonymous]
        [HttpPost("/api/tests/check")]
        public async Task<IResult> CheckTest([FromBody] TestCheckingModel test)
        {
            int result = await _baseTestService.CheckTestResult(test);

            return Results.Ok(result);
        }
        public record AnswersForTheTestCheck(int userId, int testId, AnswerVariantEntity[] answers);
        protected override void Dispose(bool disposing)
        {
            //_baseTestService.Dispose();
            base.Dispose(disposing);
        }
    }
}
