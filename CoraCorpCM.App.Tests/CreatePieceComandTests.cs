using CoraCorpCM.App.Acquisitions.Commands.CreateAcquisition.Factory;
using CoraCorpCM.App.Artists.Commands.CreateArtist.Factory;
using CoraCorpCM.App.Collections.Commands.CreateCollection.Factory;
using CoraCorpCM.App.FundingSources.Commands.CreateFundingSource.Factory;
using CoraCorpCM.App.Genres.Commands.CreateGenre.Factory;
using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.App.Locations.Commands.CreateLocation.Factory;
using CoraCorpCM.App.Media.Commands.CreateMedium.Factory;
using CoraCorpCM.App.Pieces.Commands.CreatePiece;
using CoraCorpCM.App.Pieces.Commands.CreatePiece.Factory;
using CoraCorpCM.App.Pieces.Commands.CreatePiece.Repository;
using CoraCorpCM.App.PieceSources.Commands.CreatePieceSource.Factory;
using CoraCorpCM.App.Subgenres.Commands.CreateSubgenre.Factory;
using CoraCorpCM.App.SubjectMatters.Commands.CreateSubjectMatters.Factory;
using CoraCorpCM.Common;
using CoraCorpCM.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoraCorpCM.App.Tests
{
    [TestClass]
    public class CreatePieceCommandTests
    {
        CreatePieceCommand createPieceCommand;

        CreatePieceModel createPieceModel;

        Mock<IPieceRepositoryFacade> mockRepo;
        Mock<IDateService> mockDateService;
        Mock<IPieceFactory> mockPieceFactory;
        Mock<IArtistFactory> mockArtistFactory;
        Mock<IMediumFactory> mockMediumFactory;
        Mock<IGenreFactory> mockGenreFactory;
        Mock<ISubgenreFactory> mockSubgenreFactory;
        Mock<ISubjectMatterFactory> mockSubjectMatterFactory;
        Mock<IAcquisitionFactory> mockAcquisitionFactory;
        Mock<IFundingSourceFactory> mockFundingSourceFactory;
        Mock<IPieceSourceFactory> mockPieceSourceFactory;
        Mock<ILocationFactory> mockLocationFactory;
        Mock<ICollectionFactory> mockCollectionFactory;
        Mock<IUnitOfWork> mockUnitOfWork;

        [TestInitialize]
        public void SetUp()
        {
            mockRepo = new Mock<IPieceRepositoryFacade>();
            mockRepo.Setup(r => r.GetMuseum(It.IsAny<int>())).Returns(new Museum { Id = 1 });

            mockDateService = new Mock<IDateService>();
            mockPieceFactory = new Mock<IPieceFactory>();
            mockArtistFactory = new Mock<IArtistFactory>();
            mockMediumFactory = new Mock<IMediumFactory>();
            mockGenreFactory = new Mock<IGenreFactory>();
            mockSubgenreFactory = new Mock<ISubgenreFactory>();
            mockSubjectMatterFactory = new Mock<ISubjectMatterFactory>();
            mockAcquisitionFactory = new Mock<IAcquisitionFactory>();
            mockFundingSourceFactory = new Mock<IFundingSourceFactory>();
            mockPieceSourceFactory = new Mock<IPieceSourceFactory>();
            mockLocationFactory = new Mock<ILocationFactory>();
            mockCollectionFactory = new Mock<ICollectionFactory>();
            mockUnitOfWork = new Mock<IUnitOfWork>();

            createPieceModel = new CreatePieceModel();

            createPieceCommand = new CreatePieceCommand(
                mockRepo.Object,
                mockDateService.Object,
                mockPieceFactory.Object,
                mockArtistFactory.Object,
                mockMediumFactory.Object,
                mockGenreFactory.Object,
                mockSubgenreFactory.Object,
                mockSubjectMatterFactory.Object,
                mockAcquisitionFactory.Object,
                mockFundingSourceFactory.Object,
                mockPieceSourceFactory.Object,
                mockLocationFactory.Object,
                mockCollectionFactory.Object,
                mockUnitOfWork.Object);
        }

        [TestMethod]
        public void Execute_AddsPieceToRepository()
        {
            // Arrange

            // Act
            createPieceCommand.Execute(createPieceModel);

            // Assert
            mockRepo.Verify(r => r.AddPiece(It.IsAny<Piece>()));
        }

        [TestMethod]
        public void Execute_SavesChangesToTheDatabase()
        {
            // Arrange

            // Act
            createPieceCommand.Execute(createPieceModel);

            // Assert
            mockUnitOfWork.Verify(u => u.Save());
        }
    }
}
