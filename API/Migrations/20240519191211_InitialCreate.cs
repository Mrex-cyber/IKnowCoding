using System;
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
                    is_free = table.Column<bool>(type: "bit", nullable: false)
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
                name: "rel_user_test_result",
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
                    table.PrimaryKey("PK_rel_user_test_result", x => x.id);
                    table.ForeignKey(
                        name: "FK_rel_user_test_result_Tests_test_id",
                        column: x => x.test_id,
                        principalTable: "Tests",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_rel_user_test_result_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
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
                name: "Answers",
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
                    table.PrimaryKey("PK_Answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_question_id",
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
                    { 1, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6809), "", "site.com", "The best testing website", "Best" },
                    { 2, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7091), "", "site.com", "Nice site", "Nice" },
                    { 3, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7092), "", "site.com", "Strong olympiad", "Olimpiad" },
                    { 4, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7092), "", "site.com", "~70 points of 100", "Universities" },
                    { 5, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7093), "", "site.com", "All estimation is based on the Europe system", "European estimation" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "id", "description", "is_free", "title" },
                values: new object[,]
                {
                    { 1, "C# is a general purpose object-oriented programming language.", true, "C# Start" },
                    { 2, "Java is a strongly typed, object-oriented, general-purpose programming language developed by Sun Microsystems.", true, "Java Start" },
                    { 3, "JavaScript is a multi-paradigm programming language.", true, "JavaScript Start" },
                    { 4, "C++ is a compiled, statically typed general-purpose programming language.", false, "C++ Start" }
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
                    { 1, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7795), "", "Very nice", 1 },
                    { 2, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(8236), "", "Very nice", 2 },
                    { 3, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(8237), "", "Very nice", 3 },
                    { 4, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(8237), "", "Very nice", 4 },
                    { 5, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(8238), "", "Very nice", 5 }
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
                table: "rel_user_test_result",
                columns: new[] { "id", "access_time", "finished", "finished_time", "result", "test_id", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(5298), false, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(5455), 5, 1, 1 },
                    { 2, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6001), false, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6001), 5, 2, 1 },
                    { 3, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6002), false, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6003), 0, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
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
                name: "IX_Answers_question_id",
                table: "Answers",
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
                name: "IX_rel_user_test_result_test_id",
                table: "rel_user_test_result",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_rel_user_test_result_user_id",
                table: "rel_user_test_result",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_user_id",
                table: "UserSettings",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "rel_user_test_result");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
