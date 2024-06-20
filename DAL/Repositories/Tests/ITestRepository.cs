using DAL.Models.Entities.Relationships;
using DAL.Models.Entities.Tests;

namespace DAL.Repositories.Tests
{
    public interface ITestRepository : ICrud<TestEntity>, IDisposable
    {

        Task<IEnumerable<TestEntity>> GetUserTests(string userEmail);
        Task<UserTestResultEntity> CheckTestById(string userEmail, int testId, AnswerVariantEntity[] answers);
    }
}
