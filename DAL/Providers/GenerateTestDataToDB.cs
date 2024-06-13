using DAL.Models.Entities.MainPage;
using DAL.Models.Entities.Relationships;
using DAL.Models.Entities.Tests;
using DAL.Models.Entities.User;

namespace DAL.Providers
{
    public static class GenerateTestDataToDB
    {
        public static IEnumerable<PersonEntity> People = new PersonEntity[] {
            new PersonEntity(1, "Valentyn", "Riabinchak", 1),
            new PersonEntity(2, "Vasylyna", "Leheta", 2),
            new PersonEntity(3, "Igor", "Zaitsev", 3),
            new PersonEntity(4, "Tom", "Bot", 4),
            new PersonEntity(5, "Mr. Admin", "Secret Administator", 5),
            new PersonEntity(6, "Nick", "Pick", 6),
            new PersonEntity(7, "Rafaella", "Diniz", 7),
        };

        public static IEnumerable<UserEntity> Users = new UserEntity[] {
            new UserEntity(1, "valik@gmail.com", "11111111", 1, 1, 1),
            new UserEntity(2, "vasylyna@gmail.com", "22222222", 2, 2, 2),
            new UserEntity(3, "igor@gmail.com", "33333333", 3, 3, 3),
            new UserEntity(4, "tom@gmail.com", "44444444", 4, 4, 4),
            new UserEntity(5, "admin@gmail.com", "secretKey911#", 5, 5, 5),
            new UserEntity(6, "nick@gmail.com", "55555555", 6, 6, 6),
            new UserEntity(7, "raf@gmail.com", "rafaela12#", 7, 7, 7),
        };

        public static IEnumerable<TeamAdministrator> Admins = new TeamAdministrator[] {
            new TeamAdministrator(1, 1),
            new TeamAdministrator(2, 5),
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
            new QuestionEntity(1, 1, "What is a correct syntax to output \"Hello World\" in C#?"),
            new QuestionEntity(2, 1, "C# is an alias of C++"),
            new QuestionEntity(3, 1, "How do you insert COMMENTS in C# code?"),
            new QuestionEntity(4, 1, "Which data type is used to create a variable that should store text?"),
            new QuestionEntity(5, 1, "How do you create a variable with the numeric value 5?"),
            new QuestionEntity(6, 1, "How do you create a variable with the floating number 2.8?"),

            new QuestionEntity(7, 3, "Inside which HTML element do we put the JavaScript?"),
            new QuestionEntity(8, 3, "Where is the correct place to insert a JavaScript?"),
            new QuestionEntity(9, 3, "What is the correct syntax for referring to an external script called \"xxx.js\"?"),
            new QuestionEntity(10, 3, "The external JavaScript file must contain the <script> tag."),
            new QuestionEntity(11, 3, "How do you write \"Hello World\" in an alert box?"),
            new QuestionEntity(12, 3, "How do you create a function in JavaScript?"),
        };

        public static IEnumerable<AnswerVariantEntity> Answers = new AnswerVariantEntity[] {
            new AnswerVariantEntity(1, 1, "print (\"Hello World\");", false),
            new AnswerVariantEntity(2, 1, "Console.WriteLine(\"Hello World\");", true),
            new AnswerVariantEntity(3, 1, "cout << \"Hello World\";", false),
            new AnswerVariantEntity(4, 1, "System.out.println(\"Hello World\");", false),

            new AnswerVariantEntity(5, 2, "False", true),
            new AnswerVariantEntity(6, 2, "True", false),

            new AnswerVariantEntity(7, 3, "# This is a comment", false),
            new AnswerVariantEntity(8, 3, "/* This is a comment", false),
            new AnswerVariantEntity(9, 3, "// This is a comment", true),

            new AnswerVariantEntity(10, 4, "Txt", false),
            new AnswerVariantEntity(11, 4, "str", false),
            new AnswerVariantEntity(12, 4, "myString", false),
            new AnswerVariantEntity(13, 4, "string", true),

            new AnswerVariantEntity(14, 5, "int x = 5;", true),
            new AnswerVariantEntity(15, 5, "num x = 5", false),
            new AnswerVariantEntity(16, 5, "x = 5;", false),
            new AnswerVariantEntity(17, 3, "double x = 5;", false),

            new AnswerVariantEntity(18, 6, "double x = 2.8D;", true),
            new AnswerVariantEntity(19, 6, "byte x = 2.8", false),
            new AnswerVariantEntity(20, 6, "int x = 2.8;", false),
            new AnswerVariantEntity(21, 6, "int x = 2.8D;", false),

            new AnswerVariantEntity(22, 7, "<js>", false),
            new AnswerVariantEntity(23, 7, "<script>", true),
            new AnswerVariantEntity(24, 7, "<scripting>", false),
            new AnswerVariantEntity(25, 7, "<javascript>", false),

            new AnswerVariantEntity(26, 8, "The <body> section", false),
            new AnswerVariantEntity(27, 8, "Both the <head> section and the <body> section are correct", true),
            new AnswerVariantEntity(28, 8, "The <head> section", false),

            new AnswerVariantEntity(29, 9, "<script src=\"xxx.js\">", true),
            new AnswerVariantEntity(30, 9, "<script href=\"xxx.js\">", false),
            new AnswerVariantEntity(31, 10, "<script name=\"xxx.js\">", false),

            new AnswerVariantEntity(32, 10, "True", false),
            new AnswerVariantEntity(33, 10, "False", true),

            new AnswerVariantEntity(34, 10, "alertBox(\"Hello World\");", false),
            new AnswerVariantEntity(35, 11, "msgBox(\"Hello World\");", false),
            new AnswerVariantEntity(36, 11, "msg(\"Hello World\");", false),
            new AnswerVariantEntity(37, 11, "alert(\"Hello World\");", true),

            new AnswerVariantEntity(38, 11, "function = myFunction()", false),
            new AnswerVariantEntity(39, 12, "function:myFunction()", false),
            new AnswerVariantEntity(40, 12, "function myFunction()", true),
        };

        public static IEnumerable<UserTestResultEntity> UserTestResults = new UserTestResultEntity[] {
            new UserTestResultEntity(1, 1, 1) { Result = 6 },
            new UserTestResultEntity(2, 1, 2) { Result = 4 },
            new UserTestResultEntity(3, 2, 1) { Result = 1 }
        };

        public static IEnumerable<AchievementEntity> Achievements = new AchievementEntity[] {
            new AchievementEntity(1, "Перше місце серед стартапів освітньої сфери", "https://startup-ukraine.foundation/wp-content/uploads/photo_5325816626395855791_y-1.jpg", "Загалом, до початку війни Фонд проінвестував понад 250 українських стартапів на суму більш як $6,4 млн. Було проведено 37 пітч-днів за участі 413 стартапів, а кількість поданих заявок на участь у грантових програмах Фонду перевищила 4,5 тис.", "https://uk.wikipedia.org/wiki/%D0%A3%D0%BA%D1%80%D0%B0%D1%97%D0%BD%D1%81%D1%8C%D0%BA%D0%B8%D0%B9_%D1%84%D0%BE%D0%BD%D0%B4_%D1%81%D1%82%D0%B0%D1%80%D1%82%D0%B0%D0%BF%D1%96%D0%B2"),
            new AchievementEntity(2, "Найбільша кількість донатів на ЗСУ", "https://marketer.ua/wp-content/uploads/2018/01/ua-it-ua.jpg", "Створено фонд, який за допомогою цього сайту організовує змагання на проходженні тестів.", "https://marketer.ua/ua/top-10-achievements-of-ukrainians-in-the-world-it/")
        };

        public static IEnumerable<FeedbackEntity> Feedbacks = new FeedbackEntity[] {
            new FeedbackEntity(1, "Досить корисний та захоплюючий сайт", "https://t3.ftcdn.net/jpg/02/99/04/20/360_F_299042079_vGBD7wIlSeNl7vOevWHiL93G4koMM967.jpg", 1),
            new FeedbackEntity(2, "Мені подобається випробовувати свої навички", "https://images.unsplash.com/photo-1499952127939-9bbf5af6c51c?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 2),
            new FeedbackEntity(3, "Хотілося б більше тестів", "https://st2.depositphotos.com/2931363/6569/i/450/depositphotos_65699901-stock-photo-black-man-keeping-arms-crossed.jpg", 3),
            new FeedbackEntity(4, "Покращує вміння мислити нестандартно та оцінити свої знання", "https://images.unsplash.com/photo-1500048993953-d23a436266cf?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 4),
            new FeedbackEntity(5, "Подобається дизайн сайту, допомагає зосередитися", "https://images.unsplash.com/photo-1504593811423-6dd665756598?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 5),
            new FeedbackEntity(6, "Можна весело й корисно провести час", "https://images.unsplash.com/photo-1494790108377-be9c29b29330?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 6),
            new FeedbackEntity(7, "Гарний дизайн та хороша креативність", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHBlb3BsZXxlbnwwfHwwfHx8MA%3D%3D", 7),
        };
    }
}
