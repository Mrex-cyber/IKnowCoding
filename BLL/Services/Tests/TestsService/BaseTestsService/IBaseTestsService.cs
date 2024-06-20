using BLL.Models.Tests.Answers;
using BLL.Models.Tests.Tests;
using BLL.Models.User.Relationships;

namespace BLL.Services.Tests.TestsService.BaseTestsService
{
    internal interface IBaseTestsService
    {
        public Task<IEnumerable<TestBaseModel>> GetFreeTests();
        public Task AddAccessToUserByTestId(int userId, int testId);

        public Task DeleteAccessToUserByTestId(int userId, int testId);

        public Task<UserTestResultModel> CheckTest(int userId, int testId, IEnumerable<AnswerVariantModel> answers);
    }
}
