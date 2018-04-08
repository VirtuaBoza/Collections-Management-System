using System;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Pieces.Commands.CreatePiece.Factory
{
    public class PieceFactory : IPieceFactory
    {
        public Piece Create(
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
            DateTime? insuranceExpirationDate, 
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
            int museumId)
        {
            var piece = new Piece();
            piece.RecordNumber = recordNumber;
            piece.Title = title;
            piece.AccessionNumber = accessionNumber;
            piece.CreationDay = creationDay;
            piece.CreationMonth = creationMonth;
            piece.CreationYear = creationYear;
            piece.CountryOfOrigin = countryOfOrigin;
            piece.StateOfOrigin = stateOfOrigin;
            piece.CityOfOrigin = cityOfOrigin;
            piece.Height = height;
            piece.Width = width;
            piece.Depth = depth;
            piece.UnitOfMeasure = unitOfMeasure;
            piece.EstimatedValue = estimatedValue;
            piece.Subject = subject;
            piece.CopyrightYear = copyrightYear;
            piece.CopyrightOwner = copyrightOwner;
            piece.InsurancePolicyNumber = insurancePolicyNumber;
            piece.InsuranceExpirationDate = insuranceExpirationDate;
            piece.InsuranceAmount = insuanceAmount;
            piece.InsuranceCarrier = insuranceCarrier;
            piece.IsFramed = isFramed;
            piece.IsArchived = isArchived;
            piece.Artist = artist;
            piece.Medium = medium;
            piece.Genre = genre;
            piece.Subgenre = subgenre;
            piece.SubjectMatter = subjectMatter;
            piece.Acquisition = acquisition;
            piece.CurrentLocation = currentLocation;
            piece.PermanentLocation = permanentLocation;
            piece.Collection = collection;
            piece.ApplicationUserId = lastModifiedByUserId;
            piece.LastModified = lastModified;
            piece.MuseumId = museumId;

            return piece;
        }
    }
}
