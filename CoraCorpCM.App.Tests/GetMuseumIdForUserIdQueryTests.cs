using CoraCorpCM.App.Interfaces;
using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.App.Museums.Queries;
using CoraCorpCM.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoraCorpCM.App.Tests
{
    [TestClass]
    public class GetMuseumIdForUserIdQueryTests
    {
        GetMuseumIdForUserIdQuery query;

        Mock<IUserRepository> mockRepo;

        [TestInitialize]
        public void SetUp()
        {
            mockRepo = new Mock<IUserRepository>();
            query = new GetMuseumIdForUserIdQuery(mockRepo.Object);
        }

        [TestMethod]
        public void GetMuseumIdForUserIdQuery_ReturnsInt()
        {
            // Arrange
            mockRepo
                .Setup(q => q.Get(It.IsAny<string>()))
                .Returns(new ApplicationUser { MuseumId = 1 });
            var input = "1";

            // Act
            var result = query.Execute(input);

            // Assert
            Assert.IsInstanceOfType(result, typeof(int));
        }
    }
}
