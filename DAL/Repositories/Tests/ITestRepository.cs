using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Models.Entities.Relationships;

namespace IKnowCoding.DAL.Repositories.Tests
{
    public interface ITestRepository : ICrud<TestEntity>, IDisposable
    {

        IEnumerable<TestEntity> GetUserTests(string userEmail);
        UserTestResultEntity? CheckTestById(string userEmail, int testId, AnswerVariantEntity[] answers);
    }
}
