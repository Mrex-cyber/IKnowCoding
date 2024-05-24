using DAL.Models.Entities.User;
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

        public static IEnumerable<UserSettingsEntity> UserSettings = new UserSettingsEntity[] {
            new UserSettingsEntity(1, true, 1),
            new UserSettingsEntity(2, false, 2),
            new UserSettingsEntity(3, false, 3),
            new UserSettingsEntity(4, false, 4),
            new UserSettingsEntity(5, false, 5),
        };

        public static IEnumerable<TestEntity> Tests = new TestEntity[] {
            new TestEntity(1, "C# Start", "C# is a general purpose object-oriented programming language.", true, "https://miro.medium.com/v2/resize:fit:1400/1*_NVBTVdmjt3Qvq3CZOySXg.png"),
            new TestEntity(2, "Java Start", "Java is a strongly typed, object-oriented, general-purpose programming language developed by Sun Microsystems.", false, "https://upload.wikimedia.org/wikipedia/ru/thumb/3/39/Java_logo.svg/1200px-Java_logo.svg.png"),
            new TestEntity(3, "JavaScript Start", "JavaScript is a multi-paradigm programming language.", true, "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/1200px-Unofficial_JavaScript_logo_2.svg.png"),
            new TestEntity(4, "C++ Start", "C++ is a compiled, statically typed general-purpose programming language.", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/ISO_C%2B%2B_Logo.svg/1200px-ISO_C%2B%2B_Logo.svg.png"),
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
            new UserTestResultEntity(1, 1, 1) { Result = 4 },
            new UserTestResultEntity(2, 1, 2) { Result = 4 },
            new UserTestResultEntity(3, 2, 3)
        };

        public static IEnumerable<AchievementEntity> Achievements = new AchievementEntity[] {
            new AchievementEntity(1, "Перше місце серед стартапів освітньої сфери", "https://startup-ukraine.foundation/wp-content/uploads/photo_5325816626395855791_y-1.jpg", "Загалом, до початку війни Фонд проінвестував понад 250 українських стартапів на суму більш як $6,4 млн. Було проведено 37 пітч-днів за участі 413 стартапів,[8] а кількість поданих заявок на участь у грантових програмах Фонду перевищила 4,5 тис.", "https://uk.wikipedia.org/wiki/%D0%A3%D0%BA%D1%80%D0%B0%D1%97%D0%BD%D1%81%D1%8C%D0%BA%D0%B8%D0%B9_%D1%84%D0%BE%D0%BD%D0%B4_%D1%81%D1%82%D0%B0%D1%80%D1%82%D0%B0%D0%BF%D1%96%D0%B2"),
            new AchievementEntity(2, "Найбільша кількість донатів на ЗСУ", "https://marketer.ua/wp-content/uploads/2018/01/ua-it-ua.jpg", "Створено фонд, який за допомогою цього сайту організовує змагання на проходженні тестів.", "https://marketer.ua/ua/top-10-achievements-of-ukrainians-in-the-world-it/")
        };

        public static IEnumerable<FeedbackEntity> Feedbacks = new FeedbackEntity[] {
            new FeedbackEntity(1, "Досить корисний та захоплюючий сайт", "https://t3.ftcdn.net/jpg/02/99/04/20/360_F_299042079_vGBD7wIlSeNl7vOevWHiL93G4koMM967.jpg", 1),
            new FeedbackEntity(2, "Мені подобається випробовувати свої навички", "https://images.unsplash.com/photo-1499952127939-9bbf5af6c51c?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 2),
            new FeedbackEntity(3, "Хотілося б більше тестів", "https://st2.depositphotos.com/2931363/6569/i/450/depositphotos_65699901-stock-photo-black-man-keeping-arms-crossed.jpg", 3),
            new FeedbackEntity(4, "Покращує вміння мислити нестандартно та оцінити свої знання", "https://images.unsplash.com/photo-1500048993953-d23a436266cf?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 4),
            new FeedbackEntity(5, "Подобається дизайн сайту, допомагає зосередитися", "https://images.unsplash.com/photo-1504593811423-6dd665756598?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 5),
        };
    }
}
