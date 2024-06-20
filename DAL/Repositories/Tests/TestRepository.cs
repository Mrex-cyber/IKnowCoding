using DAL.Models.Entities.Relationships;
using DAL.Models.Entities.Tests;
using DAL.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Tests
{
    public class TestRepository : ITestRepository, IDisposable
    {
        private PlatformContext _context;
        public TestRepository(PlatformContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TestEntity>> GetEntities()
        {
            IEnumerable<TestEntity> tests = await _context.Tests
                .Where(t => t.IsFree)
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .ToListAsync();

            return tests;
        }

        public async Task<IEnumerable<TestEntity>> GetUserTests(string userEmail)
        {
            IEnumerable<TestEntity> commonTests = await GetEntities();

            IEnumerable<TestEntity> userAccessedTests = _context.Tests
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .Include(t => t.TestResultEntities)
                .ToList();

            var allTests = commonTests.Concat(userAccessedTests).Distinct().ToList();

            return allTests;
        }

        public async Task<bool> AddEntity(TestEntity newTest)
        {
            try
            {
                newTest.IsFree = true;
                newTest.ImagePath ??= "";

                _context.Tests.Add(newTest);
                _context.Questions.AddRange(newTest.Questions);
                _context.Answers.AddRange(newTest.Questions.SelectMany(q => q.Answers));

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
                return false;
            }
        }
        public async Task<bool> UpdateEntity(TestEntity test)
        {
            return true;
        }

        public async Task<bool> RemoveEntity(int id)
        {
            return true;
        }
        public async Task<TestEntity?> GetEntityById(int id)
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
                UserTestResultEntity? resultObject = await (from testResultEntity in _context.UserTestResults
                                                            join users in _context.Users
                                                               on testResultEntity.UserId equals users.Id
                                                            where testResultEntity.TestId == testId
                                                               && users.Email == userEmail
                                                            select testResultEntity).FirstOrDefaultAsync();


                if (resultObject != null)
                {
                    resultObject.Result = result;
                    _context.Attach(resultObject);
                    _context.Update(resultObject);
                }
                else
                {
                    UserEntity user = _context.Users.FirstOrDefault(u => u.Email == userEmail)!;
                    resultObject = new UserTestResultEntity(0, user.Id, testId);
                    resultObject.Result = result;

                    _context.UserTestResults.Add(resultObject);
                }

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
                .Where(a => a is not null)
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
