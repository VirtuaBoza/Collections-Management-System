using CoraCorpCM.Domain.Entities;
using System;

namespace CoraCorpCM.App.Pieces.Commands.CreatePiece.Factory
{
    public interface IPieceFactory
    {
        Piece Create(
            int recordNumber,
            string title,
            string accessionNumber,
            int? creationDay,
            int? creationMonth,
            int? creationYear,
            Country countryOfOrigin,
            string stateOfOrigin,
            string cityOfOrigin,
            double? height,
            double? width,
            double? depth,
            UnitOfMeasure unitOfMeasure,
            decimal? estimatedValue,
            string subject,
            int? copyrightYear,
            string copyrightOwner,
            string insurancePolicyNumber,
            DateTime? insurancePolicyExpirationDate,
            decimal? insuanceAmount,
            string insuranceCarrier,
            bool isFramed,
            bool isArchived,
            Artist artist,
            Medium medium,
            Genre genre,
            Subgenre subgenre,
            SubjectMatter subjectMatter,
            Acquisition acquisition,
            Location currentLocation,
            Location permanentLocation,
            Collection collection,
            string lastModifiedByUserId,
            DateTime lastModified,
            int museumId);
    }
}
