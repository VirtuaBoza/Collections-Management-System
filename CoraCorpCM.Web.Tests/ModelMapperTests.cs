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
        public void ResolveToPieceModel_WithTitleOnly_ReturnsPieceWithTitleAndDefaults()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var unitOfMeasure = new UnitOfMeasure { Id = 1 };
            mockRepo.Setup(r => r.GetEntity<UnitOfMeasure>(1)).Returns(unitOfMeasure);
            var modelMapper = new ModelMapper(mockRepo.Object);
            var title = "Title";
            var pieceViewModel = new PieceViewModel { Title = title, UnitOfMeasureId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(title, piece.Title);
            Assert.IsNull(piece.AccessionNumber);
            Assert.IsNull(piece.CreationDay);
            Assert.IsNull(piece.CreationMonth);
            Assert.IsNull(piece.CreationYear);
            Assert.IsNull(piece.CountryOfOrigin);
            Assert.IsNull(piece.StateOfOrigin);
            Assert.IsNull(piece.CityOfOrigin);
            Assert.IsNull(piece.Height);
            Assert.IsNull(piece.Width);
            Assert.IsNull(piece.Depth);
            Assert.IsNull(piece.CityOfOrigin);
            Assert.AreEqual(unitOfMeasure, piece.UnitOfMeasure);
            Assert.IsNull(piece.EstimatedValue);
            Assert.IsNull(piece.Subject);
            Assert.IsNull(piece.CopyrightYear);
            Assert.IsNull(piece.CopyrightOwner);
            Assert.IsNull(piece.InsurancePolicyNumber);
            Assert.IsNull(piece.InsuranceExpirationDate);
            Assert.IsNull(piece.InsuranceAmount);
            Assert.IsNull(piece.InsuranceCarrier);
            Assert.IsFalse(piece.IsFramed);
            Assert.IsFalse(piece.IsArchived);
            Assert.IsNull(piece.Photo);
            Assert.IsNull(piece.Artist);
            Assert.IsNull(piece.Medium);
            Assert.IsNull(piece.Subgenre);
            Assert.IsNull(piece.SubjectMatter);
            Assert.IsNull(piece.Acquisition);
            Assert.IsNull(piece.CurrentLocation);
            Assert.IsNull(piece.PermanentLocation);
            Assert.IsNull(piece.Collection);
            // TODO handle mocking DateTime.Now
            Assert.AreEqual(user, piece.LastModifiedBy);
            Assert.AreEqual(0, piece.Inspections.Count);
            Assert.AreEqual(0, piece.ExhibitionPieces.Count);
            Assert.AreEqual(0, piece.LoanPieces.Count);
            Assert.AreEqual(0, piece.PieceTags.Count);
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
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { MediumId = "-1", MediumName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Medium);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewMedium_ReturnsPieceWithMediumWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { MediumId = "-1", MediumName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.Medium.Name);
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
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { GenreId = "-1", GenreName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Genre);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewGenre_ReturnsPieceWithGenreWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { GenreId = "-1", GenreName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.Genre.Name);
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
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { SubgenreId = "-1", SubgenreName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Subgenre);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewSubgenre_ReturnsPieceWithSubgenreWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { SubgenreId = "-1", SubgenreName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.Subgenre.Name);
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
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { SubjectMatterId = "-1", SubjectMatterName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.SubjectMatter);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewSubjectMatter_ReturnsPieceWithSubjectMatterWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { SubjectMatterId = "-1", SubjectMatterName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.SubjectMatter.Name);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithEstimatedValue_ReturnsPieceWithEstimatedValue()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { EstimatedValue = (decimal)100.00 };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.EstimatedValue);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithIsFramedTrue_ReturnsPieceWithIsFramedTrue()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { IsFramed = true };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsTrue(piece.IsFramed);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithCollectionId_ReturnsPieceWithCollection()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Collection>(1)).Returns(new Collection());
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { CollectionId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Collection);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewCollection_ReturnsPieceWithCollection()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { CollectionId = "-1", CollectionName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Collection);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewCollection_ReturnsPieceWithCollectionWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { CollectionId = "-1", CollectionName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.Collection.Name);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithPermLocationId_ReturnsPieceWithPermLocation()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Location>(1)).Returns(new Location());
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { PermanentLocationId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.PermanentLocation);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewPermLocation_ReturnsPieceWithPermLocation()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { PermanentLocationId = "-1", PermanentLocationName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.PermanentLocation);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewPermLocation_ReturnsPieceWithPermLocationWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { PermanentLocationId = "-1", PermanentLocationName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.PermanentLocation.Name);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewFullPermLocation_ReturnsPieceWithFullPermLocation()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var country = new Country { Id = 1 };
            mockRepo.Setup(r => r.GetEntity<Country>(1)).Returns(country);
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            var address1 = "Address 1";
            var address2 = "Address 2";
            var city = "City";
            var state = "State";
            var zip = "123456";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel
            {
                PermanentLocationId = "-1",
                PermanentLocationName = name,
                PermanentAddress1 = address1,
                PermanentAddress2 = address2,
                PermanentCity = city,
                PermanentState = state,
                PermanentZipCode = zip,
                PermanentCountryId = "1"
            };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.PermanentLocation.Name);
            Assert.AreEqual(address1, piece.PermanentLocation.Address1);
            Assert.AreEqual(address2, piece.PermanentLocation.Address2);
            Assert.AreEqual(city, piece.PermanentLocation.City);
            Assert.AreEqual(state, piece.PermanentLocation.State);
            Assert.AreEqual(zip, piece.PermanentLocation.ZipCode);
            Assert.AreEqual(country, piece.PermanentLocation.Country);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithCurrentLocationId_ReturnsPieceWithCurrentLocation()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Location>(1)).Returns(new Location());
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { CurrentLocationId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.CurrentLocation);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewCurrentLocation_ReturnsPieceWithCurrentLocation()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { CurrentLocationId = "-1", CurrentLocationName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.CurrentLocation);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewCurrentLocation_ReturnsPieceWithCurrentLocationWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { CurrentLocationId = "-1", CurrentLocationName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.CurrentLocation.Name);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewFullCurrentLocation_ReturnsPieceWithFullCurrentLocation()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var country = new Country { Id = 1 };
            mockRepo.Setup(r => r.GetEntity<Country>(1)).Returns(country);
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            var address1 = "Address 1";
            var address2 = "Address 2";
            var city = "City";
            var state = "State";
            var zip = "123456";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel
            {
                CurrentLocationId = "-1",
                CurrentLocationName = name,
                CurrentAddress1 = address1,
                CurrentAddress2 = address2,
                CurrentCity = city,
                CurrentState = state,
                CurrentZipCode = zip,
                CurrentCountryId = "1"
            };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.CurrentLocation.Name);
            Assert.AreEqual(address1, piece.CurrentLocation.Address1);
            Assert.AreEqual(address2, piece.CurrentLocation.Address2);
            Assert.AreEqual(city, piece.CurrentLocation.City);
            Assert.AreEqual(state, piece.CurrentLocation.State);
            Assert.AreEqual(zip, piece.CurrentLocation.ZipCode);
            Assert.AreEqual(country, piece.CurrentLocation.Country);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithArtistId_ReturnsPieceWithArtist()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Artist>(1)).Returns(new Artist());
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { ArtistId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Artist);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewArtist_ReturnsPieceWithArtist()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { ArtistId = "-1", ArtistName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Artist);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewArtist_ReturnsPieceWithArtistWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { ArtistId = "-1", ArtistName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.Artist.Name);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewFullArtist_ReturnsPieceWithFullArtist()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var country = new Country { Id = 1 };
            mockRepo.Setup(r => r.GetEntity<Country>(1)).Returns(country);
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            var aka = "a1";
            var city = "City";
            var state = "State";
            var birthdateString = "1/1/2018";
            var birthdate = DateTime.Parse(birthdateString);
            var deathdateString = "1/2/2018";
            var deathdate = DateTime.Parse(deathdateString);
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel
            {
                ArtistId = "-1",
                ArtistName = name,
                ArtistAlsoKnownAs = aka,
                ArtistCity = city,
                ArtistState = state,
                ArtistCountryId = "1",
                ArtistBirthdate = birthdateString,
                ArtistDeathdate = deathdateString
            };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.Artist.Name);
            Assert.AreEqual(aka, piece.Artist.AlsoKnownAs);
            Assert.AreEqual(city, piece.Artist.CityOfOrigin);
            Assert.AreEqual(state, piece.Artist.StateOfOrigin);
            Assert.AreEqual(country, piece.Artist.CountryOfOrigin);
            Assert.AreEqual(birthdate, piece.Artist.Birthdate);
            Assert.AreEqual(deathdate, piece.Artist.Deathdate);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithCreationYear_ReturnsPieceWithCreationYear()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var creationYear = 2018;
            var pieceViewModel = new PieceViewModel { CreationYear = creationYear.ToString() };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(creationYear, piece.CreationYear);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithCreationMonth_ReturnsPieceWithCreationMonth()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var creationMonth = 1;
            var pieceViewModel = new PieceViewModel { CreationMonth = creationMonth.ToString() };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(creationMonth, piece.CreationMonth);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithCreationDay_ReturnsPieceWithCreationDay()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var creationDay = 1;
            var pieceViewModel = new PieceViewModel { CreationDay = creationDay.ToString() };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(creationDay, piece.CreationDay);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithOriginCity_ReturnsPieceWithOriginCity()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var originCity = "City";
            var pieceViewModel = new PieceViewModel { OriginCity = originCity };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(originCity, piece.CityOfOrigin);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithOriginState_ReturnsPieceWithOriginState()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var originState = "State";
            var pieceViewModel = new PieceViewModel { OriginState = originState };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(originState, piece.StateOfOrigin);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithOriginCountryId_ReturnsPieceWithCountryOfOrigin()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var country = new Country { Id = 1 };
            mockRepo.Setup(r => r.GetEntity<Country>(1)).Returns(country);
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { OriginCountryId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(country, piece.CountryOfOrigin);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithDimensions_ReturnsPieceWithDimensions()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var unitOfMeasure = new UnitOfMeasure { Id = 2 };
            mockRepo.Setup(r => r.GetEntity<UnitOfMeasure>(2)).Returns(unitOfMeasure);
            var modelMapper = new ModelMapper(mockRepo.Object);
            var height = 1;
            var width = 2;
            var depth = 3;
            var pieceViewModel = new PieceViewModel
            {
                Height = height,
                Width = width,
                Depth = depth,
                UnitOfMeasureId = "2"
            };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(height, piece.Height);
            Assert.AreEqual(width, piece.Width);
            Assert.AreEqual(depth, piece.Depth);
            Assert.AreEqual(unitOfMeasure, piece.UnitOfMeasure);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithCopyright_ReturnsPieceWithCopyright()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var year = 2018;
            var owner = "Owner";
            var pieceViewModel = new PieceViewModel
            {
                CopyrightYear = year.ToString(),
                CopyrightOwner = owner
            };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(year, piece.CopyrightYear);
            Assert.AreEqual(owner, piece.CopyrightOwner);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithInsurance_ReturnsPieceWithInsurance()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var modelMapper = new ModelMapper(mockRepo.Object);
            var policyNumber = "ABC123";
            var amountInsured = (decimal)100.00;
            var expDateString = "1/1/2019";
            var expDate = DateTime.Parse(expDateString);
            var carrier = "Carrier";
            var pieceViewModel = new PieceViewModel
            {
                PolicyNumber = policyNumber,
                AmountInsured = amountInsured,
                ExpirationDate = expDateString,
                Carrier = carrier
            };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(policyNumber, piece.InsurancePolicyNumber);
            Assert.AreEqual(amountInsured, piece.InsuranceAmount);
            Assert.AreEqual(expDate, piece.InsuranceExpirationDate);
            Assert.AreEqual(carrier, piece.InsuranceCarrier);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithAcquisitionId_ReturnsPieceWithAcquisition()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var acquisition = new Acquisition { Id = 1 };
            mockRepo.Setup(r => r.GetEntity<Acquisition>(1)).Returns(acquisition);
            var modelMapper = new ModelMapper(mockRepo.Object);
            var pieceViewModel = new PieceViewModel { AcquisitionId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(acquisition, piece.Acquisition);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithDate_ReturnsPieceWithAcquisitionWithDate()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            var dateString = "1/1/2018";
            var date = DateTime.Parse(dateString);
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", AcquisitionDate = dateString };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(date, piece.Acquisition.Date);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithPieceSourceId_ReturnsPieceWithAcquisitionWithPieceSource()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var source = new PieceSource { Id = 1 };
            mockRepo.Setup(r => r.GetEntity<PieceSource>(1)).Returns(source);
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", PieceSourceId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(source, piece.Acquisition.PieceSource);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithNewPieceSource_ReturnsPieceWithAcquisitionWithPieceSource()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", PieceSourceId = "-1", PieceSourceName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Acquisition.PieceSource);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithNewPieceSourceWithName_ReturnsPieceWithAcquisitionWithPieceSourceWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", PieceSourceId = "-1", PieceSourceName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.Acquisition.PieceSource.Name);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithCost_ReturnsPieceWithAcquisitionWithCost()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            var cost = (decimal)100.00;
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", Cost = cost };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(cost, piece.Acquisition.Cost);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithFundingSourceId_ReturnsPieceWithAcquisitionWithFundingSource()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var source = new FundingSource { Id = 1 };
            mockRepo.Setup(r => r.GetEntity<FundingSource>(1)).Returns(source);
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", FundingSourceId = "1" };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(source, piece.Acquisition.FundingSource);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithNewFundingSource_ReturnsPieceWithAcquisitionWithFundingSource()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", FundingSourceId = "-1", FundingSourceName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.IsNotNull(piece.Acquisition.FundingSource);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithNewFundingSourceWithName_ReturnsPieceWithAcquisitionWithFundingSourceWithName()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            var name = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", FundingSourceId = "-1", FundingSourceName = name };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(name, piece.Acquisition.FundingSource.Name);
        }

        [TestMethod]
        public void ResolveToPieceModel_WithNewAcquisitionWithTerms_ReturnsPieceWithAcquisitionWithTerms()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var acquisition = new Acquisition { Id = 1 };
            var modelMapper = new ModelMapper(mockRepo.Object);
            var terms = "ABC123";
            // TODO Change mechanism so as not to use magic number -1 as create new
            var pieceViewModel = new PieceViewModel { AcquisitionId = "-1", Terms = terms };
            var user = new ApplicationUser();

            // Act
            var piece = modelMapper.ResolveToPieceModel(pieceViewModel, user);

            // Assert
            Assert.AreEqual(terms, piece.Acquisition.Terms);
        }
    }
}
