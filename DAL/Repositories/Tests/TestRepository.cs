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
            IEnumerable<TestEntity> tests = _context.Tests
                .AsNoTracking()
                .Where(t => t.IsFree)
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .AsEnumerable();

            return tests;
        }

        public async Task<IEnumerable<TestEntity>> GetUserTests(int userId)
        {
            IEnumerable<TestEntity> commonTests = await GetEntities();

            IEnumerable<TestEntity> userAccessedTests = _context.Tests
                .AsNoTracking()
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .Include(t => t.TestResultEntities)
                .ToList();

            var allTests = commonTests.Concat(userAccessedTests).Distinct().ToList();

            return allTests;
        }

        public TestEntity? GetEntityById(int id)
        {
            return _context.Tests.Find(id);
        }

        public async Task<bool> AddEntity(TestEntity newTest)
        {
            newTest.IsFree = true;
            newTest.ImagePath ??= "";

            _context.Tests.Add(newTest);
            _context.Questions.AddRange(newTest.Questions);
            _context.Answers.AddRange(newTest.Questions.SelectMany(q => q.Answers));

            _context.SaveChanges();
            return true;
        }

        public bool UpdateEntity(TestEntity test)
        {
            _context.Tests.Update(test);

            return true;
        }

        public async Task<bool> RemoveEntity(int id)
        {
            TestEntity? entity = GetEntityById(id);

            if (entity is null)
            {
                throw new ArgumentNullException("Test entity is null.\n Method: GetEntityByid(int id)");
            }

            _context.Tests.Remove(entity);

            return true;
        }

        public async Task<IEnumerable<int>> GetCorrectAnswerIdsByTestId(int testId)
        {
            return _context.Tests
                .First(t => t.Id == testId).Questions
                .SelectMany(q => q.Answers)
                .Where(a => a.IsRight)
                .Select(a => a.Id);
        }

        public async Task<UserTestResultEntity> GetTestResultEntity(int userId, int testId)
        {
            return await _context.UserTestResults.FirstAsync(r => r.UserId == userId && r.TestId == testId);
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
