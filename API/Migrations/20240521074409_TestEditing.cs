using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class TestEditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "date", "image_path", "source", "text", "title" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(4047), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fuk.wikipedia.org%2Fwiki%2F%25D0%25A3%25D0%25BA%25D1%2580%25D0%25B0%25D1%2597%25D0%25BD%25D1%2581%25D1%258C%25D0%25BA%25D0%25B8%25D0%25B9_%25D1%2584%25D0%25BE%25D0%25BD%25D0%25B4_%25D1%2581%25D1%2582%25D0%25B0%25D1%2580%25D1%2582%25D0%25B0%25D0%25BF%25D1%2596%25D0%25B2&psig=AOvVaw27InKEIEqDSyorw2o1gWld&ust=1716363157758000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCPjJoZSdnoYDFQAAAAAdAAAAABAE", "https://uk.wikipedia.org/wiki/%D0%A3%D0%BA%D1%80%D0%B0%D1%97%D0%BD%D1%81%D1%8C%D0%BA%D0%B8%D0%B9_%D1%84%D0%BE%D0%BD%D0%B4_%D1%81%D1%82%D0%B0%D1%80%D1%82%D0%B0%D0%BF%D1%96%D0%B2", "Загалом, до початку війни Фонд проінвестував понад 250 українських стартапів на суму більш як $6,4 млн. Було проведено 37 пітч-днів за участі 413 стартапів,[8] а кількість поданих заявок на участь у грантових програмах Фонду перевищила 4,5 тис.", "Перше місце серед стартапів освітньої сфери" });

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "date", "image_path", "source", "text", "title" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(4331), "https://marketer.ua/wp-content/uploads/2018/01/ua-it-ua.jpg", "https://marketer.ua/ua/top-10-achievements-of-ukrainians-in-the-world-it/", "Створено фонд, який за допомогою цього сайту організовує змагання на проходженні тестів.", "Найбільша кількість донатів на ЗСУ" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(5049), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.cyberlink.com%2Fblog%2Fphoto-editing-best-software%2F322%2Ffree-photo-editing-app-ios-android&psig=AOvVaw0pa2tBQMFPyU3fgcQ3Zb98&ust=1716362899129000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCIizhJ6cnoYDFQAAAAAdAAAAABAE", "Досить корисний та захоплюючий сайт" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(5345), "https://play.google.com/store/apps/details?id=vsin.t16_funny_photo&hl=ru", "Мені подобається випробовувати свої навички" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(5346), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.cutout.pro%2Fru%2Fpassport-photo-maker&psig=AOvVaw0pa2tBQMFPyU3fgcQ3Zb98&ust=1716362899129000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCIizhJ6cnoYDFQAAAAAdAAAAABAZ", "Хотілося б більше тестів" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(5347), "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fphoto&psig=AOvVaw0pa2tBQMFPyU3fgcQ3Zb98&ust=1716362899129000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCIizhJ6cnoYDFQAAAAAdAAAAABAe", "Покращує вміння мислити нестандартно та оцінити свої знання" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(5348), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fru.freepik.com%2Fphotos%2Fmale&psig=AOvVaw0pa2tBQMFPyU3fgcQ3Zb98&ust=1716362899129000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCIizhJ6cnoYDFQAAAAAdAAAAABAn", "Подобається дизайн сайту, допомагає зосередитися" });

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "id",
                keyValue: 1,
                column: "image_path",
                value: "https://www.google.com/search?q=C%23&sca_esv=43eb03caa67a0f6e&sca_upv=1&sxsrf=ADLYWIJoqKcw6OTVqHou97WgFSpkqmEQbQ:1716277232890&udm=2&source=iu&ictx=1&vet=1&fir=gZQbcdnsHuxc5M%252CSV5viJQ8DtG9OM%252C_%253BqXUkZmd5lFt_MM%252CiNAPn4lC_T_yMM%252C_%253B2Kmaj5PqBmHWrM%252CBeiW2K2u2fvmZM%252C_%253B8-pBrif-5rpyAM%252CF0mAR88WWVgAQM%252C_%253BdXdOQnz9uXv_sM%252C1KVWf25OylUnwM%252C_%253BDxVJxWX96jfIGM%252C-wqahLbR1n0AIM%252C_&usg=AI4_-kSyhjQIexqGmsu1u6BIHBCenLziQw&sa=X&ved=2ahUKEwj_srX2np6GAxVPBdsEHS2NC9gQ_h16BAhNEAE#vhid=qXUkZmd5lFt_MM&vssid=mosaic");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "id",
                keyValue: 2,
                column: "image_path",
                value: "https://www.google.com/search?q=Java&sca_esv=43eb03caa67a0f6e&sca_upv=1&sxsrf=ADLYWIJ1D9HtUKd6VM5DlelJL4pbRdMvZw:1716277244217&udm=2&source=iu&ictx=1&vet=1&fir=NN61QH37-CcFQM%252CEOIUePLXw300MM%252C_%253BtKNLYSWQnxFEQM%252CIW2FF-kZzRCBcM%252C_%253BvNrB6Xgsh-qD9M%252CgZKYe3cfhIvrfM%252C_%253BysxriJRfDlA6SM%252CfaXP3aHwxEvWwM%252C_%253BNnht0gHh8NGrmM%252CToB8tIqOU4fqPM%252C_%253BopnzypUWs4p2zM%252CmVrDzJavYcWs_M%252C_%253B-AJlmno_2oQ8IM%252CFNngVTtazmcAsM%252C_&usg=AI4_-kTrpKG14iLrKJqIeKF6fVhJYKdbzw&sa=X&ved=2ahUKEwjo0-j7np6GAxW2R_EDHf1TD9kQ_h16BAhWEAE#vhid=tKNLYSWQnxFEQM&vssid=mosaic");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "id",
                keyValue: 3,
                column: "image_path",
                value: "https://www.google.com/search?q=JavaScript&sca_esv=43eb03caa67a0f6e&sca_upv=1&sxsrf=ADLYWIJKvliyznF3RYkw0aaMd8frI51ynw:1716277256928&udm=2&source=iu&ictx=1&vet=1&fir=xJB_tNCymTHzpM%252CCkXirMXvIZwNmM%252C%252Fm%252F02p97%253BYQWDxJeX1LWg4M%252CW5aoOx-wZUSIWM%252C_%253BvcCHgmp2Y4AytM%252CMuUh9a0ML8qQ1M%252C_%253BeTe3Io_lGgha-M%252CJHG7BGUwqN5TmM%252C_%253B7oCMorh4dEqvEM%252CXcBvAFxUP5RQAM%252C_&usg=AI4_-kTPLmX_5Q_jXNvu9UxccqO4zRNY-A&sa=X&ved=2ahUKEwjBtfCBn56GAxX4X_EDHduRAjAQ_B16BAhREAE#vhid=xJB_tNCymTHzpM&vssid=mosaic");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "id",
                keyValue: 4,
                column: "image_path",
                value: "https://www.google.com/search?q=C%2B%2B&sca_esv=43eb03caa67a0f6e&sca_upv=1&sxsrf=ADLYWIJ3Qx43xPY84d0vEBIgWFToM0BDrw:1716277269526&udm=2&source=iu&ictx=1&vet=1&fir=SQ2M_m2NkVA4LM%252CbnoQF5njVnaw-M%252C%252Fm%252F0jgqg%253B18ihDXkeP5MxSM%252CvC7WIwlIoTbDcM%252C_%253BVLRUwrRK2sNv_M%252Ch2hbD-7nOjcJtM%252C_%253BBTwg5lwPuILAVM%252ChZZqlswFnAK-BM%252C_%253BCpytDU_hs09aPM%252CkIuVc11MwmCb1M%252C_%253BU6aIxu2O7h3Z8M%252CLW6HjFI5driPYM%252C_&usg=AI4_-kS1pt1q7E3h7JTp6WAENC7-vNR6Eg&sa=X&ved=2ahUKEwiQtPGHn56GAxXaBdsEHQe4AJIQ_B16BAhREAE#vhid=SQ2M_m2NkVA4LM&vssid=mosaic");

            migrationBuilder.UpdateData(
                table: "rel_user_test_result",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "access_time", "finished_time", "result" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(2541), new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(2788), 4 });

            migrationBuilder.UpdateData(
                table: "rel_user_test_result",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "access_time", "finished_time", "result" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(3207), new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(3208), 4 });

            migrationBuilder.UpdateData(
                table: "rel_user_test_result",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "access_time", "finished_time" },
                values: new object[] { new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(3209), new DateTime(2024, 5, 21, 7, 44, 8, 149, DateTimeKind.Utc).AddTicks(3210) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_path",
                table: "Tests");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "date", "image_path", "source", "text", "title" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6809), "", "site.com", "The best testing website", "Best" });

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "date", "image_path", "source", "text", "title" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7091), "", "site.com", "Nice site", "Nice" });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "id", "date", "image_path", "source", "text", "title" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7092), "", "site.com", "Strong olympiad", "Olimpiad" },
                    { 4, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7092), "", "site.com", "~70 points of 100", "Universities" },
                    { 5, new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7093), "", "site.com", "All estimation is based on the Europe system", "European estimation" }
                });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(7795), "", "Very nice" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(8236), "", "Very nice" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(8237), "", "Very nice" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(8237), "", "Very nice" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "date", "image_path", "text" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(8238), "", "Very nice" });

            migrationBuilder.UpdateData(
                table: "rel_user_test_result",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "access_time", "finished_time", "result" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(5298), new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(5455), 5 });

            migrationBuilder.UpdateData(
                table: "rel_user_test_result",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "access_time", "finished_time", "result" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6001), new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6001), 5 });

            migrationBuilder.UpdateData(
                table: "rel_user_test_result",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "access_time", "finished_time" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6002), new DateTime(2024, 5, 19, 19, 12, 11, 101, DateTimeKind.Utc).AddTicks(6003) });
        }
    }
}
