using EnglishTesterServer.Controllers;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Repositories.Tests;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace ControllersTest
{
    public class TestControllerTests
    {
        //[Fact]
        //public async Task GetById_ReturnsHttpNotFound_ForInvalidId()
        //{
        //    // Arrange
        //    int testId = 123;

        //    var mockRepo = new Mock<ITestRepository>();

        //    mockRepo.Setup(repo => repo.GetTestById(testId))
        //        .Returns((TestEntity)null);

        //    var controller = new TestController(mockRepo.Object);

        //    // Act
        //    var result = controller.OnGetTestById(123);

        //    // Assert
        //    Assert.IsType<NotFound>(result);
        //}

        //[Fact]
        //public async Task GetUserTests_Unauthorized()
        //{
        //    // Arrange
        //    string userEmail = "some.email@gmail.com";

        //    var mockRepo = new Mock<ITestRepository>();

        //    mockRepo.Setup(repo => repo.GetUserTests(userEmail))
        //        .Returns(new TestEntity[]
        //        {
        //            new TestEntity(),
        //            new TestEntity()
        //        });

        //    var controller = new TestController(mockRepo.Object);

        //    // Act
        //    var result = controller.OnGetUserTests(userEmail);

        //    // Assert
        //    Assert.IsType<JsonHttpResult<IEnumerable<TestEntity>>>(result);
        //}
    }
}