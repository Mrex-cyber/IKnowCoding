using API.Models.DTO.Answers;
using AutoMapper;
using EnglishTesterServer.DAL.UnitsOfWork;
using IKnowCoding.API.Models.DTO.Tests;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IKnowCoding.Controllers
{
    public class AdminController : Controller
    {
        private UnitOfWorkPlatform _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper)
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
        public bool OnPostNewTest([FromBody] TestRequestDto newTest)
        {
            TestEntity testEntity = _mapper.Map<TestEntity>(newTest);

            return _unitOfWork.TestRepository.AddEntity(testEntity);
        }
    }
}
