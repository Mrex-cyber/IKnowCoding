using AutoMapper;
using BLL.Models.Tests.Tests;
using BLL.Services.Tests.TestsService.BaseTestsService;
using DAL.Models.Entities.Tests;
using DAL.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.DTO.Tests;
using Shared.Models.DTO.Tests.Create;

namespace API.Controllers
{
    public class AdminController : Controller
    {
        private IBaseTestService _baseTestService;
        private readonly IMapper _mapper;

        public AdminController(IBaseTestService baseTestService, IMapper mapper)
        {
            _baseTestService = baseTestService;
            _mapper = mapper;
        }

        /// <summary>
        /// Adding new test
        /// </summary>
        /// <returns>Result of adding</returns>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST /tests/new
        ///     
        ///     {
        ///         text: string,
        ///         description: string
        ///         answers: [
        ///             {
        ///                 text: string
        ///                 isRight: false
        ///             }
        ///         ]
        ///     }
        ///     
        /// </remarks>
        /// <response code="200" link="">Added test</response>
        /// <response code="204">If the test not found</response>
        [HttpPost("/api/tests/new")]
        public async Task<IResult> OnPostNewTest([FromBody] TestCreateRequestDto newTest)
        {
            TestDetailModel model = _mapper.Map<TestDetailModel>(newTest);

            model = await _baseTestService.CreateTestByAdmin(model);

            return Results.Ok(model);
        }
    }
}
