using CoraCorpCM.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Tests
{
    internal static class MockHelper
    {
        internal static Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        internal static IEnumerable<Piece> GetTestPieces()
        {
            var pieces = new List<Piece>();
            pieces.Add(new Piece
            {

            });
            pieces.Add(new Piece
            {

            });
            return pieces;
        }

        internal static PieceViewModel GetMaximumValidPieceViewModel()
        {
            var pieceViewModel = new PieceViewModel
            {
                AccessionNumber = "ABC123",
                Title = "Title",
                Subject = "Subject",
                MediumName = "Medium",
                GenreName = "Genre",
                SubgenreName = "Subgenre",
                SubjectMatterName = "Subject Matter",
                EstimatedValue = (decimal)100.00,
                IsFramed = false,
                CollectionName = "Collection",
                PermanentLocationName = "Permanent Location",
                PermanentAddress1 = "1 Perm Address",
                PermanentAddress2 = "2 PA",
                PermanentCity = "City",
                PermanentState = "State",
                PermanentZipCode = "123456",
                PermanentCountryId = "1",
                CurrentLocationId = "1",
                ArtistName = "Artist Name",
                CreationYear = "2005"
                // TODO Fill in all possible options
            };

            return pieceViewModel;
        }
    }
}
