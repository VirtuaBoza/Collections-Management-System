using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.App.Membership;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.App.Pieces.Queries
{
    public class GetPieceListQuery : IGetPieceListQuery
    {
        private readonly IPieceRepository pieceRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public GetPieceListQuery(
            IPieceRepository pieceRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.pieceRepository = pieceRepository;
            this.userManager = userManager;
        }

        public List<PieceModel> Execute(string userId)
        {
            var pieces = pieceRepository.GetAll()
                .Where(p => p.MuseumId == userManager.FindByIdAsync(userId).Result.MuseumId)
                .Select(p => new PieceModel
                {
                    Id = p.Id,
                    RecordNumber = p.RecordNumber,
                    Title = p.Title,
                    AccessionNumber = p.AccessionNumber,
                    CreationDay = p.CreationDay,
                    CreationMonth = p.CreationMonth,
                    CreationYear = p.CreationYear,
                    CountryOfOrigin = p.CountryOfOrigin,
                    StateOfOrigin = p.StateOfOrigin,
                    CityOfOrigin = p.CityOfOrigin,
                    Height = p.Height,
                    Width = p.Width,
                    Depth = p.Depth,
                    UnitOfMeasure = p.UnitOfMeasure,
                    EstimatedValue = p.EstimatedValue,
                    Subject = p.Subject,
                    CopyrightYear = p.CopyrightYear,
                    CopyrightOwner = p.CopyrightOwner,
                    InsurancePolicyNumber = p.InsurancePolicyNumber,
                    InsuranceExpirationDate = p.InsuranceExpirationDate,
                    InsuranceAmount = p.InsuranceAmount,
                    InsuranceCarrier = p.InsuranceCarrier,
                    IsFramed = p.IsFramed,
                    IsArchived = p.IsArchived,
                    LastModified = p.LastModified,
                    Artist = p.Artist,
                    Medium = p.Medium,
                    Genre = p.Genre,
                    Subgenre = p.Subgenre,
                    SubjectMatter = p.SubjectMatter,
                    Acquisition = p.Acquisition,
                    CurrentLocation = p.CurrentLocation,
                    PermanentLocation = p.PermanentLocation,
                    Collection = p.Collection,
                    LastModifiedBy = userManager.FindByIdAsync(p.ApplicationUserId).Result
                });

            return pieces.ToList();
        }
    }
}
