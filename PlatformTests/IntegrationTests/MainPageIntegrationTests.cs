
using API.Application.Helpers;
using AutoMapper;
using DAL.Models.Entities.User;
using FluentAssertions;
using IKnowCoding.API.Models.DTO.MainPage;
using IKnowCoding.Auth;
using IKnowCoding.DAL;
using IKnowCoding.DAL.Models;
using IKnowCoding.DAL.Models.DTO.Main_Page;
using IKnowCoding.DAL.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PlatformTests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SystemTests.IntegrationTests;
using static IKnowCoding.Controllers.TestController;

namespace TradeMarket.Tests.IntegrationTests
{
    public class MainPageIntegrationTests
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/main/";
        private JsonSerializerSettings _jsonSerializingSettings;
        private IMapper _mapper;

        [SetUp]
        public void Init()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
            _jsonSerializingSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            _mapper = UnitTestHelper.CreateMapperProfile();
        }

        [Test]
        public async Task MainPageController_GetAchievements_Returns_All()
        {
            //arrange
            var expected = _mapper.Map<AchievementDto[]>(GetAchievements());

            //act
            var httpResponse = await _client.GetAsync(RequestUri + "achievements");

            //assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<AchievementDto>>(stringResponse).ToList();

            Assert.That(actual, Is.EqualTo(expected).Using(new TestEqualityComparer()), message: "GetByIdAsync method works incorrect");
        }

        [Test]
        public async Task MainPageController_GetFeedbacks_Returns_All()
        {
            //arrange
            var expected = _mapper.Map<FeedbackDto[]>(GetFeedbacksWithUsers());

            //act
            var httpResponse = await _client.GetAsync(RequestUri + "feedbacks");

            //assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<FeedbackDto>>(stringResponse).ToList();

            Assert.That(actual, Is.EqualTo(expected).Using(new TestEqualityComparer()), message: "GetByIdAsync method works incorrect");
        }

        [TestCase("Valentyn Riabinchak")]
        [TestCase("Igor Zaitsev")]
        [TestCase("Unknown")]
        public async Task MainPageController_GetFeedbacksByFullName_Returns_MatchedFeedbacks(string expectedName)
        {
            //arrange
            var expected = _mapper.Map<FeedbackDto[]>(GetFeedbacksWithUsers())
                .Where(f => f.FullName == expectedName).AsEnumerable();

            // act
            var httpResponse = await _client.GetAsync(RequestUri + "feedbacks");

            //assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<FeedbackDto>>(stringResponse).ToList();

            Assert.That(actual.Where(f => f.FullName == expectedName), Is.EqualTo(expected).Using(new TestEqualityComparer()), message: "GetByIdAsync method works incorrect");

        }

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
            _client.Dispose();
        }

        public static UserEntity[] GetUsers()
        {
            return new UserEntity[] {
                new UserEntity(1, "Valentyn", "Riabinchak", "valik@gmail.com", "11111111"),
                new UserEntity(2, "Vasylyna", "Leheta", "vasylyna@gmail.com", "22222222"),
                new UserEntity(3, "Igor", "Zaitsev", "igor@gmail.com", "33333333"),
                new UserEntity(4, "Tom", "Bot", "tom@gmail.com", "44444444"),
                new UserEntity(5, "Mr. Admin", "Secret Administator", "admin@gmail.com", "secretKey911#"),
            };
        }

        public static AchievementEntity[] GetAchievements()
        {
            return new AchievementEntity[] {
                new AchievementEntity(1, "Перше місце серед стартапів освітньої сфери", "https://startup-ukraine.foundation/wp-content/uploads/photo_5325816626395855791_y-1.jpg", "Загалом, до початку війни Фонд проінвестував понад 250 українських стартапів на суму більш як $6,4 млн. Було проведено 37 пітч-днів за участі 413 стартапів,[8] а кількість поданих заявок на участь у грантових програмах Фонду перевищила 4,5 тис.", "https://uk.wikipedia.org/wiki/%D0%A3%D0%BA%D1%80%D0%B0%D1%97%D0%BD%D1%81%D1%8C%D0%BA%D0%B8%D0%B9_%D1%84%D0%BE%D0%BD%D0%B4_%D1%81%D1%82%D0%B0%D1%80%D1%82%D0%B0%D0%BF%D1%96%D0%B2"),
                new AchievementEntity(2, "Найбільша кількість донатів на ЗСУ", "https://marketer.ua/wp-content/uploads/2018/01/ua-it-ua.jpg", "Створено фонд, який за допомогою цього сайту організовує змагання на проходженні тестів.", "https://marketer.ua/ua/top-10-achievements-of-ukrainians-in-the-world-it/")
            };
        }

        public static FeedbackEntity[] GetFeedbacks()
        {
            return new FeedbackEntity[] {
                new FeedbackEntity(1, "Досить корисний та захоплюючий сайт", "https://t3.ftcdn.net/jpg/02/99/04/20/360_F_299042079_vGBD7wIlSeNl7vOevWHiL93G4koMM967.jpg", 1),
                new FeedbackEntity(2, "Мені подобається випробовувати свої навички", "https://images.unsplash.com/photo-1499952127939-9bbf5af6c51c?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 2),
                new FeedbackEntity(3, "Хотілося б більше тестів", "https://st2.depositphotos.com/2931363/6569/i/450/depositphotos_65699901-stock-photo-black-man-keeping-arms-crossed.jpg", 3),
                new FeedbackEntity(4, "Покращує вміння мислити нестандартно та оцінити свої знання", "https://images.unsplash.com/photo-1500048993953-d23a436266cf?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 4),
                new FeedbackEntity(5, "Подобається дизайн сайту, допомагає зосередитися", "https://images.unsplash.com/photo-1504593811423-6dd665756598?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 5),
            };
        }

        public static FeedbackEntity[] GetFeedbacksWithUsers()
        {
            return (from f in GetFeedbacks()
                join u in GetUsers()
                    on f.Id equals u.FeedbackId
                select f).ToArray();
        }
    }
}
