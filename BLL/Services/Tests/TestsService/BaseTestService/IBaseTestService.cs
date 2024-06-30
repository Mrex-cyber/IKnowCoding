using BLL.Models.Tests.Answers;
using BLL.Models.Tests.Tests;
using BLL.Models.User.Relationships;
using DAL.Repositories;

namespace BLL.Services.Tests.TestsService.BaseTestsService
{
    public interface IBaseTestService
    {
        public Task<IEnumerable<TestDetailModel>> GetAllFreeTests();

        public Task<IEnumerable<TestDetailModel>> GetAllUserAccessedTests(int userId);

        public Task<TestBaseModel> GetTestById(int id);

        public Task<TestDetailModel> CreateTestByAdmin(TestDetailModel model);

        public Task AddAccessToUserByTestId(int userId, int testId);

        public Task DeleteAccessToUserByTestId(int userId, int testId);

        public Task<int> CheckTestResult(TestCheckingModel test);
    }
}
