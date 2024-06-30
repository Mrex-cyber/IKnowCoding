using AutoMapper;
using BLL.Models.Tests.Tests;
using DAL.Models.Entities.Relationships;
using DAL.Models.Entities.Tests;
using DAL.UnitsOfWork;

namespace BLL.Services.Tests.TestsService.BaseTestsService
{
    public class BaseTestService : IBaseTestService
    {
        private UnitOfWorkPlatform _unitOfWork;
        private readonly IMapper _mapper;

        public BaseTestService(IUnitOfWork unitOfWork, IMapper mapper)
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

        public async Task<IEnumerable<TestDetailModel>> GetAllFreeTests()
        {
            var commonTests = await _unitOfWork.TestRepository.GetEntities();

            var mappedTests = _mapper.Map<IEnumerable<TestDetailModel>>(commonTests);

            return mappedTests;
        }

        public async Task<IEnumerable<TestDetailModel>> GetAllUserAccessedTests(int userId)
        {
            var userTests = await _unitOfWork.TestRepository.GetUserTests(userId);

            return _mapper.Map<IEnumerable<TestDetailModel>>(userTests);
        }

        public async Task<TestBaseModel> GetTestById(int id)
        {
            var test = _unitOfWork.TestRepository.GetEntityById(id);

            return _mapper.Map<TestBaseModel>(test);
        }

        public async Task<TestDetailModel> CreateTestByAdmin(TestDetailModel model)
        {
            TestEntity entity = _mapper.Map<TestEntity>(model);

            await _unitOfWork.TestRepository.AddEntity(entity);

            return model;
        }

        public async Task<int> CheckTestResult(TestCheckingModel test)
        {
            UserTestResultEntity userTestResult = await _unitOfWork.TestRepository.GetTestResultEntity(test.UserId, test.Id);

            IEnumerable<int> rightAnswerIds = await _unitOfWork.TestRepository.GetCorrectAnswerIdsByTestId(test.Id);

            int result = test.AnswerIds.Intersect(rightAnswerIds).Count();

            userTestResult.Result = result;

            _unitOfWork.Save();

            return result;
        }

        public Task AddAccessToUserByTestId(int userId, int testId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccessToUserByTestId(int userId, int testId)
        {
            throw new NotImplementedException();
        }
    }
}
