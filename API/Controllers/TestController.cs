using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using EnglishTesterServer.DAL.UnitsOfWork;
using IKnowCoding.DAL.Models.Entities;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using AutoMapper;
using IKnowCoding.DAL.UnitsOfWork;
using IKnowCoding.API.Models.DTO.Tests;

namespace EnglishTesterServer.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private UnitOfWorkPlatform _unitOfWork;
        private readonly IMapper _mapper;

        public TestController(IUnitOfWork unitOfWork, IMapper mapper) {
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
        public IResult OnGetTests()
        {
            var commonTests = _unitOfWork.TestRepository.GetEntities();

            if (commonTests.Count() == 0)
            {
                return Results.NoContent();
            }

            string json = JsonConvert.SerializeObject(_mapper.Map<TestDto[]>(commonTests), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

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
        public IResult OnGetUserTests([FromBody] string userEmail)
        {
            var userTests = _unitOfWork.TestRepository.GetUserTests(userEmail);

            if (userTests.Count() == 0)
            {
                return Results.NoContent();
            }

            return Results.Json(_mapper.Map<TestDto>(userTests));
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
            var test = _unitOfWork.TestRepository.GetEntityById(testId);

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
        public IResult OnPostCheckTestByid([FromBody] AnswersForTheTestCheck testData)
        {
            try
            {
                int result = _unitOfWork.TestRepository.CheckTestById(testData.userEmail, testData.testId, testData.answers).Result;
                _unitOfWork.Save();

                return Results.Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Results.Json(ex.Message);
            }

        }
        public record AnswersForTheTestCheck(string userEmail, int testId, AnswerVariantEntity[] answers);
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
