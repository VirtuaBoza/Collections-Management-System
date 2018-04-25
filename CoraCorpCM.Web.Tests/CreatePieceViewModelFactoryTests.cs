using CoraCorpCM.Application.Acquisitions.Queries.GetAcquisitionList;
using CoraCorpCM.Application.Artists.Queries.GetArtistList;
using CoraCorpCM.Application.Collections.Queries.GetCollectionList;
using CoraCorpCM.Application.Countries.Queries;
using CoraCorpCM.Application.FundingSources.Queries.GetFundingSourceList;
using CoraCorpCM.Application.Genres.Queries.GetGenreList;
using CoraCorpCM.Application.Locations.Queries.GetLocationList;
using CoraCorpCM.Application.Media.Queries;
using CoraCorpCM.Application.Media.Queries.GetMediumList;
using CoraCorpCM.Application.Museums.Queries;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Application.PieceSources.Queries.GetPieceSourceList;
using CoraCorpCM.Application.Subgenres.Queries.GetSubgenreList;
using CoraCorpCM.Application.SubjectMatters.Queries.GetSubjectMatterList;
using CoraCorpCM.Application.UnitsOfMeasure.Queries.GetUnitsOfMeasureList;
using CoraCorpCM.Web.Services.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class CreatePieceViewModelFactoryTests
    {
        CreatePieceViewModelFactory factory;

        Mock<IGetMuseumForUserIdQuery> mockMuseumQuery;
        Mock<IGetCountryListQuery> mockCountryListQuery;
        Mock<IGetMediumListQuery> mockMediumListQuery;
        Mock<IGetGenreListQuery> mockGenreListQuery;
        Mock<IGetSubgenreListQuery> mockSubgenreListQuery;
        Mock<IGetSubjectMatterListQuery> mockSubjectMatterListQuery;
        Mock<IGetLocationListQuery> mockLocationListQuery;
        Mock<IGetUnitOfMeasureListQuery> mockUnitOfMeasureListQuery;
        Mock<IGetArtistListQuery> mockArtistListQuery;
        Mock<IGetAcquisitionListQuery> mockAcquisitionListQuery;
        Mock<IGetPieceSourceListQuery> mockPieceSourceListQuery;
        Mock<IGetFundingSourceListQuery> mockFundingSourceListQuery;
        Mock<IGetCollectionListQuery> mockCollectionListQuery;

        CountryModel country;
        MediumModel medium;
        GenreModel genre;
        SubgenreModel subgenre;
        SubjectMatterModel subjectMatter;
        LocationModel location;
        UnitOfMeasureModel unitOfMeasure;
        ArtistModel artist;
        AcquisitionModel acquisition;
        PieceSourceModel pieceSource;
        FundingSourceModel fundingSource;
        CollectionModel collection;

        string userId;

        [TestInitialize]
        public void SetUp()
        {
            var museum = new MuseumModel { Id = 1 };
            mockMuseumQuery = new Mock<IGetMuseumForUserIdQuery>();
            mockMuseumQuery.Setup(q => q.Execute(It.IsAny<string>()))
                .Returns(museum);

            country = new CountryModel { Id = 2, Name = "country" };
            mockCountryListQuery = new Mock<IGetCountryListQuery>();
            mockCountryListQuery.Setup(q => q.Execute())
                .Returns(new List<CountryModel> { country });

            medium = new MediumModel { Id = 3, Name = "medium" };
            mockMediumListQuery = new Mock<IGetMediumListQuery>();
            mockMediumListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<MediumModel> { medium });

            genre = new GenreModel { Id = 4, Name = "genre" };
            mockGenreListQuery = new Mock<IGetGenreListQuery>();
            mockGenreListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<GenreModel> { genre });

            subgenre = new SubgenreModel { Id = 5, Name = "subgenre" };
            mockSubgenreListQuery = new Mock<IGetSubgenreListQuery>();
            mockSubgenreListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<SubgenreModel> { subgenre });

            subjectMatter = new SubjectMatterModel { Id = 6, Name = "subject matter" };
            mockSubjectMatterListQuery = new Mock<IGetSubjectMatterListQuery>();
            mockSubjectMatterListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<SubjectMatterModel> { subjectMatter });

            location = new LocationModel { Id = 7, Name = "location" };
            mockLocationListQuery = new Mock<IGetLocationListQuery>();
            mockLocationListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<LocationModel> { location });

            unitOfMeasure = new UnitOfMeasureModel { Id = 8, Abbreviation = "unit of measure" };
            mockUnitOfMeasureListQuery = new Mock<IGetUnitOfMeasureListQuery>();
            mockUnitOfMeasureListQuery.Setup(q => q.Execute())
                .Returns(new List<UnitOfMeasureModel> { unitOfMeasure });

            artist = new ArtistModel { Id = 9, Name = "artist" };
            mockArtistListQuery = new Mock<IGetArtistListQuery>();
            mockArtistListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<ArtistModel> { artist });

            acquisition = new AcquisitionModel { Id = 10 };
            mockAcquisitionListQuery = new Mock<IGetAcquisitionListQuery>();
            mockAcquisitionListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<AcquisitionModel> { acquisition });

            pieceSource = new PieceSourceModel { Id = 11, Name = "piece source" };
            mockPieceSourceListQuery = new Mock<IGetPieceSourceListQuery>();
            mockPieceSourceListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<PieceSourceModel> { pieceSource });

            fundingSource = new FundingSourceModel { Id = 12, Name = "funding source" };
            mockFundingSourceListQuery = new Mock<IGetFundingSourceListQuery>();
            mockFundingSourceListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<FundingSourceModel> { fundingSource });

            collection = new CollectionModel { Id = 13, Name = "collection" };
            mockCollectionListQuery = new Mock<IGetCollectionListQuery>();
            mockCollectionListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<CollectionModel> { collection });

            factory = new CreatePieceViewModelFactory(
                mockMuseumQuery.Object,
                mockCountryListQuery.Object,
                mockMediumListQuery.Object,
                mockGenreListQuery.Object,
                mockSubgenreListQuery.Object,
                mockSubjectMatterListQuery.Object,
                mockLocationListQuery.Object,
                mockUnitOfMeasureListQuery.Object,
                mockArtistListQuery.Object,
                mockAcquisitionListQuery.Object,
                mockPieceSourceListQuery.Object,
                mockFundingSourceListQuery.Object,
                mockCollectionListQuery.Object);

            userId = "userId";
        }

        [TestMethod]
        public void Create_ReturnsWithCreatePieceModel()
        {
            // Arrange

            // Act
            var result = factory.Create(userId).Piece;

            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatePieceModel));
        }

        [TestMethod]
        public void Create_SetsCountries()
        {
            // Arrange
            var expectedValue = country.Id.ToString();
            var expectedText = country.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Countries.Single().Value;
            var actualText = result.Countries.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsMedia()
        {
            // Arrange
            var expectedValue = medium.Id.ToString();
            var expectedText = medium.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Media.Single().Value;
            var actualText = result.Media.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsGenres()
        {
            // Arrange
            var expectedValue = genre.Id.ToString();
            var expectedText = genre.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Genres.Single().Value;
            var actualText = result.Genres.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsSubgenres()
        {
            // Arrange
            var expectedValue = subgenre.Id.ToString();
            var expectedText = subgenre.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Subgenres.Single().Value;
            var actualText = result.Subgenres.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsSubjectMatters()
        {
            // Arrange
            var expectedValue = subjectMatter.Id.ToString();
            var expectedText = subjectMatter.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.SubjectMatters.Single().Value;
            var actualText = result.SubjectMatters.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsLocations()
        {
            // Arrange
            var expectedValue = location.Id.ToString();
            var expectedText = location.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Locations.Single().Value;
            var actualText = result.Locations.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsUnitsOfMeasure()
        {
            // Arrange
            var expectedValue = unitOfMeasure.Id.ToString();
            var expectedText = unitOfMeasure.Abbreviation;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.UnitsOfMeasure.Single().Value;
            var actualText = result.UnitsOfMeasure.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsArtists()
        {
            // Arrange
            var expectedValue = artist.Id.ToString();
            var expectedText = artist.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Artists.Single().Value;
            var actualText = result.Artists.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_WithDateOnlyAcquisition_SetsAcquisitions()
        {
            // Arrange
            var expectedValue = acquisition.Id.ToString();
            acquisition.Date = DateTime.Parse("12/30/2020");
            var expectedText = acquisition.Date?.ToString("MM/dd/yyyy") + " ";

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Acquisitions.Single().Value;
            var actualText = result.Acquisitions.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_WithSourceOnlyAcquisition_SetsAcquisitions()
        {
            // Arrange
            var expectedValue = acquisition.Id.ToString();
            acquisition.PieceSource = pieceSource.Name;
            var expectedText = " " + acquisition.PieceSource;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Acquisitions.Single().Value;
            var actualText = result.Acquisitions.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsAcquisitions()
        {
            // Arrange
            var expectedValue = acquisition.Id.ToString();
            acquisition.Date = DateTime.Parse("12/30/2020");
            acquisition.PieceSource = pieceSource.Name;
            var expectedText = acquisition.Date?.ToString("MM/dd/yyyy") + " " + acquisition.PieceSource;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Acquisitions.Single().Value;
            var actualText = result.Acquisitions.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsPieceSources()
        {
            // Arrange
            var expectedValue = pieceSource.Id.ToString();
            var expectedText = pieceSource.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.PieceSources.Single().Value;
            var actualText = result.PieceSources.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsFundingSources()
        {
            // Arrange
            var expectedValue = fundingSource.Id.ToString();
            var expectedText = fundingSource.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.FundingSources.Single().Value;
            var actualText = result.FundingSources.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Create_SetsCollections()
        {
            // Arrange
            var expectedValue = collection.Id.ToString();
            var expectedText = collection.Name;

            // Act
            var result = factory.Create(userId);
            var actualValue = result.Collections.Single().Value;
            var actualText = result.Collections.Single().Text;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedText, actualText);
        }
    }
}
