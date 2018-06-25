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
        public string Title { get; set; }
        public string AccessionNumber { get; set; }
        public int? CreationDay { get; set; }
        public int? CreationMonth { get; set; }
        public int? CreationYear { get; set; }
        public int? CountryOfOriginId { get; set; }
        public string StateOfOrigin { get; set; }
        public string CityOfOrigin { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Depth { get; set; }
        public int UnitOfMeasureId { get; set; }
        public decimal? EstimatedValue { get; set; }
        public string Subject { get; set; }
        public int? CopyrightYear { get; set; }
        public string CopyrightOwner { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTime? InsuranceExpirationDate { get; set; }
        public decimal? InsuranceAmount { get; set; }
        public string InsuranceCarrier { get; set; }
        public bool IsFramed { get; set; }
        public bool IsArchived { get; set; }
        public int? ArtistId { get; set; }
        public int? MediumId { get; set; }
        public int? GenreId { get; set; }
        public int? SubgenreId { get; set; }
        public int? SubjectMatterId { get; set; }
        public int? AcquisitionId { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? PermanentLocationId { get; set; }
        public int? CollectionId { get; set; }

        public DateTime? AcquisitionDate { get; set; }
        public int? PieceSourceId { get; set; }
        public string PieceSourceName { get; set; }
        public decimal? AcquisitionCost { get; set; }
        public int? FundingSourceId { get; set; }
        public string FundingSourceName { get; set; }
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

        public string GenreName { get; set; }

        public string MediumName { get; set; }

        public string PermanentLocationName { get; set; }
        public string PermanentLocationAddress1 { get; set; }
        public string PermanentLocationAddress2 { get; set; }
        public string PermanentLocationCity { get; set; }
        public string PermanentLocationState { get; set; }
        public string PermanentLocationZipCode { get; set; }
        public int? PermanentLocationCountryId { get; set; }


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

            if (createPieceViewModel.ArtistId < 0 && string.IsNullOrWhiteSpace(createPieceViewModel.ArtistName) && (
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
