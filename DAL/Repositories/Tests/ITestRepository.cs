using DAL.Models.Entities.Relationships;
using DAL.Models.Entities.Tests;

namespace DAL.Repositories.Tests
{
    public interface ITestRepository : ICrud<TestEntity>, IDisposable
    {

        Task<IEnumerable<TestEntity>> GetUserTests(int userId);
        Task<UserTestResultEntity> CheckTestById(int userId, int testId, AnswerVariantEntity[] answers);
    }
}
