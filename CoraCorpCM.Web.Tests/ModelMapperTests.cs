using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoraCorpCM.Data;
using CoraCorpCM.Domain.Models;
using CoraCorpCM.Web.Utilities;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Moq;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class ModelMapperTests
    {
        [TestMethod]
        public void ResolveToPieceModel_WithNullViewModel_ThrowsArgumentNullException()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var user = new ApplicationUser();

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => modelMapper.ResolveToPieceModel(null, user));
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNullUser_ThrowsArgumentNullException()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel();

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => modelMapper.ResolveToPieceModel(pieceViewModel, null));
        }

        [TestMethod]
        public void ResolveToPieceModel_WithTitle_ReturnsPieceWithTitle()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var title = "Title";
            var pieceViewModel = new PieceViewModel { Title = title };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(title, piece.Title);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithAccessionNumber_ReturnsPieceWithAccessionNumber()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var accessionNumber = "ABC123";
            var pieceViewModel = new PieceViewModel { AccessionNumber = accessionNumber };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(accessionNumber, piece.AccessionNumber);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithSubject_ReturnsPieceWithSubject()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var subject = "ABC123";
            var pieceViewModel = new PieceViewModel { Subject = subject };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(subject, piece.Subject);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithMediumId_ReturnsPieceWithMedium()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Medium>(1)).Returns(new Medium());
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { MediumId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Medium);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewMedium_ReturnsPieceWithMedium()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { MediumId = "-1", MediumName = "ABC123" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Medium);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithGenreId_ReturnsPieceWithGenre()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Genre>(1)).Returns(new Genre());
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { GenreId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Genre);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewGenre_ReturnsPieceWithGenre()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { GenreId = "-1", GenreName = "ABC123" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Genre);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithSubgenreId_ReturnsPieceWithSubgenre()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Subgenre>(1)).Returns(new Subgenre());
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { SubgenreId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Subgenre);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewSubgenre_ReturnsPieceWithSubgenre()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { SubgenreId = "-1", SubgenreName = "ABC123" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Subgenre);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithSubjectMatterId_ReturnsPieceWithSubjectMatter()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<SubjectMatter>(1)).Returns(new SubjectMatter());
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { SubjectMatterId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.SubjectMatter);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewSubjectMatter_ReturnsPieceWithSubjectMatter()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { SubjectMatterId = "-1", SubjectMatterName = "ABC123" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.SubjectMatter);
        }
    }
}
