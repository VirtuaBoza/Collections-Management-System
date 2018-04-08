using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.App.Membership;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.App.Pieces.Queries
{
    public class GetPieceQuery : IGetPieceQuery
    {
        private readonly IPieceRepository pieceRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public GetPieceQuery(
            IPieceRepository pieceRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.pieceRepository = pieceRepository;
            this.userManager = userManager;
        }

        public PieceModel Execute(int id)
        {
            var piece = pieceRepository.Get(id);

            var pieceModel = new PieceModel
            {
                Id = piece.Id,
                RecordNumber = piece.RecordNumber,
                Title = piece.Title,
                AccessionNumber = piece.AccessionNumber,
                CreationDay = piece.CreationDay,
                CreationMonth = piece.CreationMonth,
                CreationYear = piece.CreationYear,
                CountryOfOrigin = piece.CountryOfOrigin,
                StateOfOrigin = piece.StateOfOrigin,
                CityOfOrigin = piece.CityOfOrigin,
                Height = piece.Height,
                Width = piece.Width,
                Depth = piece.Depth,
                UnitOfMeasure = piece.UnitOfMeasure,
                EstimatedValue = piece.EstimatedValue,
                Subject = piece.Subject,
                CopyrightYear = piece.CopyrightYear,
                CopyrightOwner = piece.CopyrightOwner,
                InsurancePolicyNumber = piece.InsurancePolicyNumber,
                InsuranceExpirationDate = piece.InsuranceExpirationDate,
                InsuranceAmount = piece.InsuranceAmount,
                InsuranceCarrier = piece.InsuranceCarrier,
                IsFramed = piece.IsFramed,
                IsArchived = piece.IsArchived,
                LastModified = piece.LastModified,
                Artist = piece.Artist,
                Medium = piece.Medium,
                Genre = piece.Genre,
                Subgenre = piece.Subgenre,
                SubjectMatter = piece.SubjectMatter,
                Acquisition = piece.Acquisition,
                CurrentLocation = piece.CurrentLocation,
                PermanentLocation = piece.PermanentLocation,
                Collection = piece.Collection,
                LastModifiedBy = userManager.FindByIdAsync(piece.ApplicationUserId).Result
            };

            return pieceModel;
        }
    }
}
