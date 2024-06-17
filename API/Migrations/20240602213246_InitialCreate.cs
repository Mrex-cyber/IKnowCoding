using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "obj_achievements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_achievements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "obj_tests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_free = table.Column<bool>(type: "bit", nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_tests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "obj_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feedback_id = table.Column<int>(type: "int", nullable: false),
                    settings_id = table.Column<int>(type: "int", nullable: false),
                    person_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "obj_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    test_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_obj_questions_obj_tests_test_id",
                        column: x => x.test_id,
                        principalTable: "obj_tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obj_feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "FK_obj_feedbacks_obj_users_user_id",
                        column: x => x.user_id,
                        principalTable: "obj_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obj_people",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_people", x => x.id);
                    table.ForeignKey(
                        name: "FK_obj_people_obj_users_user_id",
                        column: x => x.user_id,
                        principalTable: "obj_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obj_team_admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_team_admins", x => x.id);
                    table.ForeignKey(
                        name: "FK_obj_team_admins_obj_users_user_id",
                        column: x => x.user_id,
                        principalTable: "obj_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obj_user_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    access_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    access_token_expire_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    refresh_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refresh_token_expire_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_admin = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_user_settings", x => x.id);
                    table.ForeignKey(
                        name: "FK_obj_user_settings_obj_users_user_id",
                        column: x => x.user_id,
                        principalTable: "obj_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rel_user_test_results",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    test_id = table.Column<int>(type: "int", nullable: false),
                    finished = table.Column<bool>(type: "bit", nullable: false),
                    access_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    finished_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    result = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rel_user_test_results", x => x.id);
                    table.ForeignKey(
                        name: "FK_rel_user_test_results_obj_tests_test_id",
                        column: x => x.test_id,
                        principalTable: "obj_tests",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_rel_user_test_results_obj_users_user_id",
                        column: x => x.user_id,
                        principalTable: "obj_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "obj_answers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_right = table.Column<bool>(type: "bit", nullable: false),
                    question_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_obj_answers_obj_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "obj_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obj_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obj_teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_obj_teams_obj_team_admins_user_id",
                        column: x => x.user_id,
                        principalTable: "obj_team_admins",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rel_users_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rel_users_teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_rel_users_teams_obj_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "obj_teams",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_rel_users_teams_obj_users_user_id",
                        column: x => x.user_id,
                        principalTable: "obj_users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "obj_achievements",
                columns: new[] { "id", "date", "image_path", "source", "text", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(1218), "https://startup-ukraine.foundation/wp-content/uploads/photo_5325816626395855791_y-1.jpg", "https://uk.wikipedia.org/wiki/%D0%A3%D0%BA%D1%80%D0%B0%D1%97%D0%BD%D1%81%D1%8C%D0%BA%D0%B8%D0%B9_%D1%84%D0%BE%D0%BD%D0%B4_%D1%81%D1%82%D0%B0%D1%80%D1%82%D0%B0%D0%BF%D1%96%D0%B2", "Загалом, до початку війни Фонд проінвестував понад 250 українських стартапів на суму більш як $6,4 млн. Було проведено 37 пітч-днів за участі 413 стартапів, а кількість поданих заявок на участь у грантових програмах Фонду перевищила 4,5 тис.", "Перше місце серед стартапів освітньої сфери" },
                    { 2, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(1521), "https://marketer.ua/wp-content/uploads/2018/01/ua-it-ua.jpg", "https://marketer.ua/ua/top-10-achievements-of-ukrainians-in-the-world-it/", "Створено фонд, який за допомогою цього сайту організовує змагання на проходженні тестів.", "Найбільша кількість донатів на ЗСУ" }
                });

            migrationBuilder.InsertData(
                table: "obj_tests",
                columns: new[] { "id", "description", "image_path", "is_free", "title" },
                values: new object[,]
                {
                    { 1, "C# is a general purpose object-oriented programming language.", "https://miro.medium.com/v2/resize:fit:1400/1*_NVBTVdmjt3Qvq3CZOySXg.png", true, "C# Start" },
                    { 2, "Java is a strongly typed, object-oriented, general-purpose programming language developed by Sun Microsystems.", "https://upload.wikimedia.org/wikipedia/ru/thumb/3/39/Java_logo.svg/1200px-Java_logo.svg.png", false, "Java Start" },
                    { 3, "JavaScript is a multi-paradigm programming language.", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/1200px-Unofficial_JavaScript_logo_2.svg.png", true, "JavaScript Start" },
                    { 4, "C++ is a compiled, statically typed general-purpose programming language.", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/ISO_C%2B%2B_Logo.svg/1200px-ISO_C%2B%2B_Logo.svg.png", false, "C++ Start" }
                });

            migrationBuilder.InsertData(
                table: "obj_users",
                columns: new[] { "id", "email", "feedback_id", "password", "person_id", "settings_id" },
                values: new object[,]
                {
                    { 1, "valik@gmail.com", 1, "11111111", 1, 1 },
                    { 2, "vasylyna@gmail.com", 2, "22222222", 2, 2 },
                    { 3, "igor@gmail.com", 3, "33333333", 3, 3 },
                    { 4, "tom@gmail.com", 4, "44444444", 4, 4 },
                    { 5, "admin@gmail.com", 5, "secretKey911#", 5, 5 },
                    { 6, "nick@gmail.com", 6, "55555555", 6, 6 },
                    { 7, "raf@gmail.com", 7, "rafaela12#", 7, 7 }
                });

            migrationBuilder.InsertData(
                table: "obj_feedbacks",
                columns: new[] { "id", "date", "image_path", "text", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(2236), "https://t3.ftcdn.net/jpg/02/99/04/20/360_F_299042079_vGBD7wIlSeNl7vOevWHiL93G4koMM967.jpg", "Досить корисний та захоплюючий сайт", 1 },
                    { 2, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(2595), "https://images.unsplash.com/photo-1499952127939-9bbf5af6c51c?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Мені подобається випробовувати свої навички", 2 },
                    { 3, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(2596), "https://st2.depositphotos.com/2931363/6569/i/450/depositphotos_65699901-stock-photo-black-man-keeping-arms-crossed.jpg", "Хотілося б більше тестів", 3 },
                    { 4, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(2597), "https://images.unsplash.com/photo-1500048993953-d23a436266cf?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Покращує вміння мислити нестандартно та оцінити свої знання", 4 },
                    { 5, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(2598), "https://images.unsplash.com/photo-1504593811423-6dd665756598?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Подобається дизайн сайту, допомагає зосередитися", 5 },
                    { 6, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(2598), "https://images.unsplash.com/photo-1494790108377-be9c29b29330?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Можна весело й корисно провести час", 6 },
                    { 7, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(2599), "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHBlb3BsZXxlbnwwfHwwfHx8MA%3D%3D", "Гарний дизайн та хороша креативність", 7 }
                });

            migrationBuilder.InsertData(
                table: "obj_questions",
                columns: new[] { "id", "test_id", "text" },
                values: new object[,]
                {
                    { 1, 1, "What is a correct syntax to output \"Hello World\" in C#?" },
                    { 2, 1, "C# is an alias of C++" },
                    { 3, 1, "How do you insert COMMENTS in C# code?" },
                    { 4, 1, "Which data type is used to create a variable that should store text?" },
                    { 5, 1, "How do you create a variable with the numeric value 5?" },
                    { 6, 1, "How do you create a variable with the floating number 2.8?" },
                    { 7, 3, "Inside which HTML element do we put the JavaScript?" },
                    { 8, 3, "Where is the correct place to insert a JavaScript?" },
                    { 9, 3, "What is the correct syntax for referring to an external script called \"xxx.js\"?" },
                    { 10, 3, "The external JavaScript file must contain the <script> tag." },
                    { 11, 3, "How do you write \"Hello World\" in an alert box?" },
                    { 12, 3, "How do you create a function in JavaScript?" }
                });

            migrationBuilder.InsertData(
                table: "obj_user_settings",
                columns: new[] { "id", "access_token", "access_token_expire_time", "is_admin", "refresh_token", "refresh_token_expire_time", "user_id" },
                values: new object[,]
                {
                    { 1, null, null, true, null, null, 1 },
                    { 2, null, null, false, null, null, 2 },
                    { 3, null, null, false, null, null, 3 },
                    { 4, null, null, false, null, null, 4 },
                    { 5, null, null, false, null, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "rel_user_test_results",
                columns: new[] { "id", "access_time", "finished", "finished_time", "result", "test_id", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 2, 21, 32, 45, 453, DateTimeKind.Utc).AddTicks(9475), false, new DateTime(2024, 6, 2, 21, 32, 45, 453, DateTimeKind.Utc).AddTicks(9656), 6, 1, 1 },
                    { 2, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(189), false, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(189), 4, 2, 1 },
                    { 3, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(191), false, new DateTime(2024, 6, 2, 21, 32, 45, 454, DateTimeKind.Utc).AddTicks(191), 1, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "obj_answers",
                columns: new[] { "id", "is_right", "question_id", "text" },
                values: new object[,]
                {
                    { 1, false, 1, "print (\"Hello World\");" },
                    { 2, true, 1, "Console.WriteLine(\"Hello World\");" },
                    { 3, false, 1, "cout << \"Hello World\";" },
                    { 4, false, 1, "System.out.println(\"Hello World\");" },
                    { 5, true, 2, "False" },
                    { 6, false, 2, "True" },
                    { 7, false, 3, "# This is a comment" },
                    { 8, false, 3, "/* This is a comment" },
                    { 9, true, 3, "// This is a comment" },
                    { 10, false, 4, "Txt" },
                    { 11, false, 4, "str" },
                    { 12, false, 4, "myString" },
                    { 13, true, 4, "string" },
                    { 14, true, 5, "int x = 5;" },
                    { 15, false, 5, "num x = 5" },
                    { 16, false, 5, "x = 5;" },
                    { 17, false, 3, "double x = 5;" },
                    { 18, true, 6, "double x = 2.8D;" },
                    { 19, false, 6, "byte x = 2.8" },
                    { 20, false, 6, "int x = 2.8;" },
                    { 21, false, 6, "int x = 2.8D;" },
                    { 22, false, 7, "<js>" },
                    { 23, true, 7, "<script>" },
                    { 24, false, 7, "<scripting>" },
                    { 25, false, 7, "<javascript>" },
                    { 26, false, 8, "The <body> section" },
                    { 27, true, 8, "Both the <head> section and the <body> section are correct" },
                    { 28, false, 8, "The <head> section" },
                    { 29, true, 9, "<script src=\"xxx.js\">" },
                    { 30, false, 9, "<script href=\"xxx.js\">" },
                    { 31, false, 10, "<script name=\"xxx.js\">" },
                    { 32, false, 10, "True" },
                    { 33, true, 10, "False" },
                    { 34, false, 10, "alertBox(\"Hello World\");" },
                    { 35, false, 11, "msgBox(\"Hello World\");" },
                    { 36, false, 11, "msg(\"Hello World\");" },
                    { 37, true, 11, "alert(\"Hello World\");" },
                    { 38, false, 11, "function = myFunction()" },
                    { 39, false, 12, "function:myFunction()" },
                    { 40, true, 12, "function myFunction()" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_obj_answers_question_id",
                table: "obj_answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_obj_feedbacks_user_id",
                table: "obj_feedbacks",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_obj_people_user_id",
                table: "obj_people",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_obj_questions_test_id",
                table: "obj_questions",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_obj_team_admins_user_id",
                table: "obj_team_admins",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_obj_teams_user_id",
                table: "obj_teams",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_obj_user_settings_user_id",
                table: "obj_user_settings",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rel_user_test_results_test_id",
                table: "rel_user_test_results",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_rel_user_test_results_user_id",
                table: "rel_user_test_results",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_rel_users_teams_team_id",
                table: "rel_users_teams",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_rel_users_teams_user_id",
                table: "rel_users_teams",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "obj_achievements");

            migrationBuilder.DropTable(
                name: "obj_answers");

            migrationBuilder.DropTable(
                name: "obj_feedbacks");

            migrationBuilder.DropTable(
                name: "obj_people");

            migrationBuilder.DropTable(
                name: "obj_user_settings");

            migrationBuilder.DropTable(
                name: "rel_user_test_results");

            migrationBuilder.DropTable(
                name: "rel_users_teams");

            migrationBuilder.DropTable(
                name: "obj_questions");

            migrationBuilder.DropTable(
                name: "obj_teams");

            migrationBuilder.DropTable(
                name: "obj_tests");

            migrationBuilder.DropTable(
                name: "obj_team_admins");

            migrationBuilder.DropTable(
                name: "obj_users");
        }
    }
}
