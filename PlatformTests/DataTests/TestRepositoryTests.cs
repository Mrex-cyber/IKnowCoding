using IKnowCoding.DAL;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Repositories.Tests;
using NUnit.Framework;
using PlatformTests.TestHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeMarket.Tests.DataTests
{
    [TestFixture]
    public class TestRepositoryTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public async Task TestRepository_GetByIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new PlatformContext();

            var testRepository = new TestRepository(context);

            var test = testRepository.GetEntityById(id);

            var expected = GetFullTests().FirstOrDefault(x => x.Id == id);

            Assert.That(test, Is.EqualTo(expected).Using(new TestEqualityComparer()), message: "GetByIdAsync method works incorrect");
        }

        [Test]
        public async Task TestRepository_GetAllAsync_ReturnsAllValues()
        {
            using var context = new PlatformContext(UnitTestHelper.GetUnitTestDbOptions());

            var testRepository = new TestRepository(context);

            var tests = testRepository.GetEntities();

            Assert.That(tests.OrderBy(p => p.Id).AsEnumerable(), Is.EqualTo(GetFullTests().OrderBy(p => p.Id).AsEnumerable()).Using(new TestEqualityComparer()), message: "GetAllAsync method works incorrect");
        }

        public static IEnumerable<TestEntity> GetTests()
        {
            return new TestEntity[] {
                new TestEntity(1, "C# Start", "C# is a general purpose object-oriented programming language.", true, "https://miro.medium.com/v2/resize:fit:1400/1*_NVBTVdmjt3Qvq3CZOySXg.png"),
                new TestEntity(2, "Java Start", "Java is a strongly typed, object-oriented, general-purpose programming language developed by Sun Microsystems.", true, "https://upload.wikimedia.org/wikipedia/ru/thumb/3/39/Java_logo.svg/1200px-Java_logo.svg.png"),
                new TestEntity(3, "JavaScript Start", "JavaScript is a multi-paradigm programming language.", true, "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/1200px-Unofficial_JavaScript_logo_2.svg.png"),
                new TestEntity(4, "C++ Start", "C++ is a compiled, statically typed general-purpose programming language.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/ISO_C%2B%2B_Logo.svg/1200px-ISO_C%2B%2B_Logo.svg.png"),
            };
        }

        public static IEnumerable<QuestionEntity> GetQuestions()
        {
            return new QuestionEntity[] {
                new QuestionEntity(1, 1, "Choose 1"),
                new QuestionEntity(2, 1, "Choose 2"),
                new QuestionEntity(3, 1, "Choose 3"),
                new QuestionEntity(4, 2, "Choose 1"),
                new QuestionEntity(5, 3, "Choose 1"),
            };
        }

        public static IEnumerable<AnswerVariantEntity> GetAnswers()
        {
            return new AnswerVariantEntity[] {
                new AnswerVariantEntity(1, 1, "1", true),
                new AnswerVariantEntity(2, 1, "2", false),
                new AnswerVariantEntity(3, 1, "3", false),
                new AnswerVariantEntity(4, 1, "4", false),

                new AnswerVariantEntity(5, 2, "1", false),
                new AnswerVariantEntity(6, 2, "2", true),
                new AnswerVariantEntity(7, 2, "3", false),
                new AnswerVariantEntity(8, 2, "4", false),

                new AnswerVariantEntity(9, 3, "1", false),
                new AnswerVariantEntity(10, 3, "2", false),
                new AnswerVariantEntity(11, 3, "3", true),
                new AnswerVariantEntity(12, 3, "4", false),

                new AnswerVariantEntity(13, 4, "1", true),
                new AnswerVariantEntity(14, 4, "2", false),

                new AnswerVariantEntity(15, 5, "1", true),
                new AnswerVariantEntity(16, 5, "2", false),
            };
        }

        public static List<TestEntity> GetFullTests()
        {
            return (from test in GetTests()
                    join question in GetQuestions()
                        on test.Id equals question.TestId
                    join answer in GetAnswers()
                        on question.Id equals answer.QuestionId
                    select test).Distinct().ToList();

        }
    }
}
