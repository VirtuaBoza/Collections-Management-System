using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition;
using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition.Repository;
using CoraCorpCM.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoraCorpCM.Application.Tests
{
    [TestClass]
    public class CreateAcquisitionCommandTests
    {
        CreateAcquisitionCommand command;

        Mock<IAcquisitionRepositoryFacade> mockRepo;

        [TestInitialize]
        public void SetUp()
        {
            mockRepo = new Mock<IAcquisitionRepositoryFacade>();

            command = new CreateAcquisitionCommand(mockRepo.Object);
        }

        [TestMethod]
        public void Execute_AddsAcquisitionToRepository()
        {
            // Arrange
            var createAcquisitionModel = new CreateAcquisitionModel();

            // Act
            command.Execute(createAcquisitionModel);

            // Assert
            mockRepo.Verify(r => r.AddAcquisition(It.IsAny<Acquisition>()));
        }
    }
}
