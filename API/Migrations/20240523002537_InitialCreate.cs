﻿using System;
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
                name: "Achievements",
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
                    table.PrimaryKey("PK_Achievements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
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
                    table.PrimaryKey("PK_Tests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feedback_id = table.Column<int>(type: "int", nullable: false),
                    user_settings_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    test_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_test_id",
                        column: x => x.test_id,
                        principalTable: "Tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
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
                    table.PrimaryKey("PK_Feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
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
                    table.PrimaryKey("PK_UserSettings", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTestResults",
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
                    table.PrimaryKey("PK_UserTestResults", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserTestResults_Tests_test_id",
                        column: x => x.test_id,
                        principalTable: "Tests",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserTestResults_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AnswerVariants",
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
                    table.PrimaryKey("PK_AnswerVariants", x => x.id);
                    table.ForeignKey(
                        name: "FK_AnswerVariants_Questions_question_id",
                        column: x => x.question_id,
                        principalTable: "Questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "id", "date", "image_path", "source", "text", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(4074), "https://startup-ukraine.foundation/wp-content/uploads/photo_5325816626395855791_y-1.jpg", "https://uk.wikipedia.org/wiki/%D0%A3%D0%BA%D1%80%D0%B0%D1%97%D0%BD%D1%81%D1%8C%D0%BA%D0%B8%D0%B9_%D1%84%D0%BE%D0%BD%D0%B4_%D1%81%D1%82%D0%B0%D1%80%D1%82%D0%B0%D0%BF%D1%96%D0%B2", "Загалом, до початку війни Фонд проінвестував понад 250 українських стартапів на суму більш як $6,4 млн. Було проведено 37 пітч-днів за участі 413 стартапів,[8] а кількість поданих заявок на участь у грантових програмах Фонду перевищила 4,5 тис.", "Перше місце серед стартапів освітньої сфери" },
                    { 2, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(4727), "https://marketer.ua/wp-content/uploads/2018/01/ua-it-ua.jpg", "https://marketer.ua/ua/top-10-achievements-of-ukrainians-in-the-world-it/", "Створено фонд, який за допомогою цього сайту організовує змагання на проходженні тестів.", "Найбільша кількість донатів на ЗСУ" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "id", "description", "image_path", "is_free", "title" },
                values: new object[,]
                {
                    { 1, "C# is a general purpose object-oriented programming language.", "https://miro.medium.com/v2/resize:fit:1400/1*_NVBTVdmjt3Qvq3CZOySXg.png", true, "C# Start" },
                    { 2, "Java is a strongly typed, object-oriented, general-purpose programming language developed by Sun Microsystems.", "https://upload.wikimedia.org/wikipedia/ru/thumb/3/39/Java_logo.svg/1200px-Java_logo.svg.png", false, "Java Start" },
                    { 3, "JavaScript is a multi-paradigm programming language.", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/1200px-Unofficial_JavaScript_logo_2.svg.png", true, "JavaScript Start" },
                    { 4, "C++ is a compiled, statically typed general-purpose programming language.", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/ISO_C%2B%2B_Logo.svg/1200px-ISO_C%2B%2B_Logo.svg.png", false, "C++ Start" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "feedback_id", "firstName", "lastName", "password", "user_settings_id" },
                values: new object[,]
                {
                    { 1, "valik@gmail.com", 0, "Valentyn", "Riabinchak", "11111111", 0 },
                    { 2, "vasylyna@gmail.com", 0, "Vasylyna", "Leheta", "22222222", 0 },
                    { 3, "igor@gmail.com", 0, "Igor", "Zaitsev", "33333333", 0 },
                    { 4, "tom@gmail.com", 0, "Tom", "Bot", "44444444", 0 },
                    { 5, "admin@gmail.com", 0, "Mr. Admin", "Secret Administator", "secretKey911#", 0 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "id", "date", "image_path", "text", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(6087), "https://t3.ftcdn.net/jpg/02/99/04/20/360_F_299042079_vGBD7wIlSeNl7vOevWHiL93G4koMM967.jpg", "Досить корисний та захоплюючий сайт", 1 },
                    { 2, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(6725), "https://images.unsplash.com/photo-1499952127939-9bbf5af6c51c?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Мені подобається випробовувати свої навички", 2 },
                    { 3, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(6727), "https://st2.depositphotos.com/2931363/6569/i/450/depositphotos_65699901-stock-photo-black-man-keeping-arms-crossed.jpg", "Хотілося б більше тестів", 3 },
                    { 4, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(6728), "https://images.unsplash.com/photo-1500048993953-d23a436266cf?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Покращує вміння мислити нестандартно та оцінити свої знання", 4 },
                    { 5, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(6729), "https://images.unsplash.com/photo-1504593811423-6dd665756598?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Подобається дизайн сайту, допомагає зосередитися", 5 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "id", "test_id", "text" },
                values: new object[,]
                {
                    { 1, 1, "Choose 1" },
                    { 2, 1, "Choose 2" },
                    { 3, 1, "Choose 3" },
                    { 4, 2, "Choose 1" },
                    { 5, 3, "Choose 1" }
                });

            migrationBuilder.InsertData(
                table: "UserSettings",
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
                table: "UserTestResults",
                columns: new[] { "id", "access_time", "finished", "finished_time", "result", "test_id", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(1040), false, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(1406), 4, 1, 1 },
                    { 2, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(2231), false, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(2232), 4, 2, 1 },
                    { 3, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(2234), false, new DateTime(2024, 5, 23, 0, 25, 37, 374, DateTimeKind.Utc).AddTicks(2234), 0, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "AnswerVariants",
                columns: new[] { "id", "is_right", "question_id", "text" },
                values: new object[,]
                {
                    { 1, true, 1, "1" },
                    { 2, false, 1, "2" },
                    { 3, false, 1, "3" },
                    { 4, false, 1, "4" },
                    { 5, false, 2, "1" },
                    { 6, true, 2, "2" },
                    { 7, false, 2, "3" },
                    { 8, false, 2, "4" },
                    { 9, false, 3, "1" },
                    { 10, false, 3, "2" },
                    { 11, true, 3, "3" },
                    { 12, false, 3, "4" },
                    { 13, true, 4, "1" },
                    { 14, false, 4, "2" },
                    { 15, true, 5, "1" },
                    { 16, false, 5, "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVariants_question_id",
                table: "AnswerVariants",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_user_id",
                table: "Feedbacks",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_test_id",
                table: "Questions",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_user_id",
                table: "UserSettings",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResults_test_id",
                table: "UserTestResults",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResults_user_id",
                table: "UserTestResults",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "AnswerVariants");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "UserTestResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
