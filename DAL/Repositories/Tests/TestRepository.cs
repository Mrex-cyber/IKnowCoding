using DAL.Models.Entities.User;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Models.Entities.Relationships;
using Microsoft.EntityFrameworkCore;

namespace IKnowCoding.DAL.Repositories.Tests
{
    public class TestRepository : ITestRepository, IDisposable
    {
        private PlatformContext _context;
        public TestRepository(PlatformContext context)
        {
            _context = context;
        }

        public IEnumerable<TestEntity> GetEntities()
        {
            IEnumerable<TestEntity> tests = _context.Tests
                .Where(t => t.IsFree)
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .ToList();

            return tests;
        }

        public IEnumerable<TestEntity> GetUserTests(string userEmail)
        {
            IEnumerable<TestEntity> commonTests = GetEntities();

            IEnumerable<TestEntity> userAccessedTests = _context.Tests
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .Include(t => t.TestResultEntities)
                .ToList();

            return commonTests.Concat(userAccessedTests);
        }

        public bool AddEntity(TestEntity newTest)
        {
            try
            {
                _context.Add(newTest);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdatedEntity(TestEntity test)
        {
            return true;
        }
        public bool RemoveEntity(int id)
        {
            return true;
        }
        public TestEntity? GetEntityById(int id)
        {
            return _context.Tests.Find(id);
        }
        public async Task<UserTestResultEntity> CheckTestById(string userEmail, int testId, AnswerVariantEntity[] userAnswers)
        {
            int result = CalculatePoints(userAnswers);

            return await GetResultAndSave(userEmail, testId, result);
        }

        private async Task<AnswerVariantEntity[]> GetAllRightAnswers(AnswerVariantEntity[] userAnswers)
        {
            int[] userAnswersIds = userAnswers.Select(a => a.Id).ToArray();

            AnswerVariantEntity[] rightAnswers = await _context.Answers
                .Where(a => a.IsRight 
                    && userAnswersIds.Contains(a.Id))
                .ToArrayAsync();

            return rightAnswers;
        }        

        private async Task<UserTestResultEntity> GetResultAndSave(string userEmail, int testId, int result)
        {
            try
            {
                var userTestResult = from testResultEntity in _context.UserTestResults
                                      join users in _context.Users
                                         on testResultEntity.UserId equals users.Id
                                      where testResultEntity.TestId == testId
                                         && users.Email == userEmail
                                      select testResultEntity;

                UserTestResultEntity? resultObject = await userTestResult.FirstAsync();

                resultObject.Result = result;

                await SaveAsync();

                return resultObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private int CalculatePoints(AnswerVariantEntity[] userAnswers)
        {
            int result = userAnswers
                .IntersectBy(_context.Answers.Select(a => a.Id), a => a.Id).Count();

            return result;
        }

        private bool WriteResultToDB(ref UserTestResultEntity resultObject, int result)
        {
            try
            {
                resultObject.Result = result;
                Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        
    }
}
