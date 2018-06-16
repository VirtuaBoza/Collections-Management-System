using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoraCorpCM.Web.ViewModels.CollectionViewModels
{
    public class CreatePieceViewModel
    {
        [Required]
        public string PieceTitle { get; set; }
        public string PieceAccessionNumber { get; set; }
        public int? PieceCreationDay { get; set; }
        public int? PieceCreationMonth { get; set; }
        public int? PieceCreationYear { get; set; }
        public int? PieceCountryOfOriginId { get; set; }
        public string PieceStateOfOrigin { get; set; }
        public string PieceCityOfOrigin { get; set; }
        public double? PieceHeight { get; set; }
        public double? PieceWidth { get; set; }
        public double? PieceDepth { get; set; }
        public int PieceUnitOfMeasureId { get; set; }
        public decimal? PieceEstimatedValue { get; set; }
        public string PieceSubject { get; set; }
        public int? PieceCopyrightYear { get; set; }
        public string PieceCopyrightOwner { get; set; }
        public string PieceInsurancePolicyNumber { get; set; }
        public DateTime? PieceInsuranceExpirationDate { get; set; }
        public decimal? PieceInsuranceAmount { get; set; }
        public string PieceInsuranceCarrier { get; set; }
        public bool PieceIsFramed { get; set; }
        public bool PieceIsArchived { get; set; }
        public int? PieceArtistId { get; set; }
        public int? PieceMediumId { get; set; }
        public int? PieceGenreId { get; set; }
        public int? PieceSubgenreId { get; set; }
        public int? PieceSubjectMatterId { get; set; }
        public int? PieceAcquisitionId { get; set; }
        public int? PieceCurrentLocationId { get; set; }
        public int? PiecePermanentLocationId { get; set; }
        public int? PieceCollectionId { get; set; }
        public DateTime PieceLastModified { get; set; }
        public string PieceLastModifiedByUserId { get; set; }

        public DateTime? AcquisitionDate { get; set; }
        public int? AcquisitionPieceSourceId { get; set; }
        public decimal? AcquisitionCost { get; set; }
        public int? AcquisitionFundingSourceId { get; set; }
        public string AcquisitionTerms { get; set; }

        [CreatePieceViewModelArtistName]
        public string ArtistName { get; set; }
        public string ArtistAlsoKnownAs { get; set; }
        public string ArtistStateOfOrigin { get; set; }
        public string ArtistCityOfOrigin { get; set; }
        public int? ArtistCountryOfOriginId { get; set; }
        public DateTime? ArtistBirthDate { get; set; }
        public DateTime? ArtistDeathDate { get; set; }

        public string CollectionName { get; set; }

        public string CurrentLocationName { get; set; }
        public string CurrentLocationAddress1 { get; set; }
        public string CurrentLocationAddress2 { get; set; }
        public string CurrentLocationCity { get; set; }
        public string CurrentLocationState { get; set; }
        public string CurrentLocationZipCode { get; set; }
        public int? CurrentLocationCountryId { get; set; }

        public string FundingSourceName { get; set; }

        public string GenreName { get; set; }

        public string MediumName { get; set; }

        public string PermanentLocationName { get; set; }
        public string PermanentLocationAddress1 { get; set; }
        public string PermanentLocationAddress2 { get; set; }
        public string PermanentLocationCity { get; set; }
        public string PermanentLocationState { get; set; }
        public string PermanentLocationZipCode { get; set; }
        public int? PermanentLocationCountryId { get; set; }

        public string PieceSourceName { get; set; }

        public string SubgenreName { get; set; }

        public string SubjectMatterName { get; set; }

        public IEnumerable<SelectListItem> Media { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Subgenres { get; set; }
        public IEnumerable<SelectListItem> SubjectMatters { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> UnitsOfMeasure { get; set; }
        public IEnumerable<SelectListItem> Artists { get; set; }
        public IEnumerable<SelectListItem> Acquisitions { get; set; }
        public IEnumerable<SelectListItem> PieceSources { get; set; }
        public IEnumerable<SelectListItem> FundingSources { get; set; }
        public IEnumerable<SelectListItem> Collections { get; set; }
    }

    public class CreatePieceViewModelArtistNameAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var createPieceViewModel = (CreatePieceViewModel)validationContext.ObjectInstance;

            if (createPieceViewModel.PieceArtistId < 0 && string.IsNullOrWhiteSpace(createPieceViewModel.ArtistName) && (
                !string.IsNullOrWhiteSpace(createPieceViewModel.ArtistAlsoKnownAs) ||
                createPieceViewModel.ArtistBirthDate == null ||
                !string.IsNullOrWhiteSpace(createPieceViewModel.ArtistCityOfOrigin) ||
                createPieceViewModel.ArtistDeathDate == null ||
                !string.IsNullOrWhiteSpace(createPieceViewModel.ArtistStateOfOrigin)))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-namedartist", GetErrorMessage());
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }

        private string GetErrorMessage()
        {
            return "New artists must have a name.";
        }
    }
}
