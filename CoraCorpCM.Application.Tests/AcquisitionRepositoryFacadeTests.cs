using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition.Repository;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Tests
{
    [TestClass]
    public class AcquisitionRepositoryFacadeTests
    {
        AcquisitionRepositoryFacade acquisitionRepositoryFacade;

        [TestInitialize]
        public void SetUp()
        {
            acquisitionRepositoryFacade = new AcquisitionRepositoryFacade();
        }

        [TestMethod]
        public void ClassStructure_AddAcquisitionExtists()
        {
            // Arrange
            var acquisition = new Acquisition();

            // Act
            // Assert
            acquisitionRepositoryFacade.AddAcquisition(acquisition);
        }
    }
}
