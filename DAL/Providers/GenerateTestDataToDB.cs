using IKnowCoding.API.Models.DTO.MainPage;
using IKnowCoding.DAL.Models.DTO.Main_Page;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Models.Entities.Relationships;

namespace DAL.Providers
{
    public static class GenerateTestDataToDB
    {
        public static IEnumerable<UserEntity> Users = new UserEntity[] {
            new UserEntity(1, "Valentyn", "Riabinchak", "valik@gmail.com", "11111111"),
            new UserEntity(2, "Vasylyna", "Leheta", "vasylyna@gmail.com", "22222222"),
            new UserEntity(3, "Igor", "Zaitsev", "igor@gmail.com", "33333333"),
            new UserEntity(4, "Tom", "Bot", "tom@gmail.com", "44444444"),
            new UserEntity(5, "Mr. Admin", "Secret Administator", "admin@gmail.com", "secretKey911#"),
        };

        public static IEnumerable<TestEntity> Tests = new TestEntity[] {
            new TestEntity(1, "C# Start", "C# is a general purpose object-oriented programming language.", true),
            new TestEntity(2, "Java Start", "Java is a strongly typed, object-oriented, general-purpose programming language developed by Sun Microsystems.", true),
            new TestEntity(3, "JavaScript Start", "JavaScript is a multi-paradigm programming language.", true),
            new TestEntity(4, "C++ Start", "C++ is a compiled, statically typed general-purpose programming language.", false),
        };

        public static IEnumerable<QuestionEntity> Questions = new QuestionEntity[] {
            new QuestionEntity(1, 1, "Choose 1"),
            new QuestionEntity(2, 1, "Choose 2"),
            new QuestionEntity(3, 1, "Choose 3"),
            new QuestionEntity(4, 2, "Choose 1"),
            new QuestionEntity(5, 3, "Choose 1"),
        };

        public static IEnumerable<AnswerVariantEntity> Answers = new AnswerVariantEntity[] {
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

        public static IEnumerable<UserTestResultEntity> UserTestResults = new UserTestResultEntity[] {
            new UserTestResultEntity(1, 1, 1) { Result = 5 },
            new UserTestResultEntity(2, 1, 2) { Result = 5 },
            new UserTestResultEntity(3, 2, 3)
        };

        public static IEnumerable<AchievementEntity> Achievements = new AchievementEntity[] {
            new AchievementEntity(1, "Best", "", "The best testing website", "site.com"),
            new AchievementEntity(2, "Nice", "", "Nice site", "site.com"),
            new AchievementEntity(3, "Olimpiad", "", "Strong olympiad", "site.com"),
            new AchievementEntity(4, "Universities", "", "~70 points of 100", "site.com"),
            new AchievementEntity(5, "European estimation", "", "All estimation is based on the Europe system", "site.com"),
        };

        public static IEnumerable<FeedbackEntity> Feedbacks = new FeedbackEntity[] {
            new FeedbackEntity(1, "Very nice", "", 1),
            new FeedbackEntity(2, "Very nice", "", 2),
            new FeedbackEntity(3, "Very nice", "", 3),
            new FeedbackEntity(4, "Very nice", "", 4),
            new FeedbackEntity(5, "Very nice", "", 5),
        };
    }
}
