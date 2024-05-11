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
            var tests = _context.Tests
                .Where(t => t.IsFree)
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .ToList();

            return tests;
        }

        public IEnumerable<TestEntity> GetUserTests(string userEmail)
        {
            List<TestEntity> allTests = GetEntities().ToList();

            return allTests;
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
        public UserTestResultEntity? CheckTestById(string userEmail, int testId, AnswerVariantEntity[] userAnswers)
        {
            AnswerVariantEntity[] rightAnswers = GetAllRightAnswersForQuestions(userAnswers);

            int result = CalculatePoints(userAnswers, rightAnswers);

            return GetResultAndSave(userEmail, testId, result);
        }

        private AnswerVariantEntity[] GetAllRightAnswersForQuestions(AnswerVariantEntity[] userAnswers)
        {
            AnswerVariantEntity[] rightAnswers = new AnswerVariantEntity[userAnswers.Length];

            for (int i = 0; i < userAnswers.Length; i++)
            {
                AnswerVariantEntity currentAnswer = userAnswers[i];

                var variant = from answer in _context.Answers
                              join questions in _context.Questions
                                on answer.QuestionId equals questions.Id
                              where answer.IsRight == true
                                && questions.Id == currentAnswer.QuestionId
                              select new AnswerVariantEntity()
                              {
                                  Id = answer.Id,
                                  Text = answer.Text,
                                  QuestionId = currentAnswer.QuestionId
                              };

                if (variant is not null)
                {
                    rightAnswers[i] = variant.First();
                }
            }

            return rightAnswers;
        }        

        private UserTestResultEntity GetResultAndSave(string userEmail, int testId, int result)
        {
            try
            {
                var userToTestField = from userToTest in _context.UserTestResults
                                      join users in _context.Users
                                         on userToTest.UserId equals users.Id
                                      where userToTest.TestId == testId
                                         && users.Email == userEmail
                                      select userToTest;

                UserTestResultEntity resultObject = userToTestField.First();

                if (WriteResultToDB(ref resultObject, result))
                {
                    return resultObject;
                }
                else throw new Exception("Writing to DB was canceled");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private int CalculatePoints(AnswerVariantEntity[] userAnswers, AnswerVariantEntity[] rightAnswers)
        {
            int result = 0;

            foreach (AnswerVariantEntity rightAnswer in rightAnswers)
            {
                if (userAnswers.Where(a => a.QuestionId == rightAnswer.QuestionId && a.Id == rightAnswer.Id).Count() > 0)
                {
                    result++;
                }
            }

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
