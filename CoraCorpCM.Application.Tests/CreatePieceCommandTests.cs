using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition.Factory;
using CoraCorpCM.Application.Artists.Commands.CreateArtist.Factory;
using CoraCorpCM.Application.Collections.Commands.CreateCollection.Factory;
using CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource.Factory;
using CoraCorpCM.Application.Genres.Commands.CreateGenre.Factory;
using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Locations.Commands.CreateLocation.Factory;
using CoraCorpCM.Application.Media.Commands.CreateMedium.Factory;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece.Factory;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece.Repository;
using CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource.Factory;
using CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre.Factory;
using CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter.Factory;
using CoraCorpCM.Common;
using CoraCorpCM.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoraCorpCM.Application.Tests
{
    [TestClass]
    public class CreatePieceCommandTests
    {
        CreatePieceCommand createPieceCommand;

        CreatePieceModel createPieceModel;

        Mock<IPieceRepositoryFacade> mockRepo;
        Mock<IDateTimeService> mockDateService;
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

            mockDateService = new Mock<IDateTimeService>();

            mockPieceFactory = new Mock<IPieceFactory>();
            mockPieceFactory.SetReturnsDefault(new Piece());

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
