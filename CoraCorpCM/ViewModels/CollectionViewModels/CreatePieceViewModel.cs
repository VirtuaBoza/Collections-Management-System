using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.ViewModels.CollectionViewModels
{
    public class CreatePieceViewModel
    {
        // Piece Info
        [Required]
        public string Title { get; set; }

        public string Subject { get; set; }

        [Display(Name = "Assession Number")]
        public string AccessionNumber { get; set; }

        [Display(Name = "Year")]
        public int CreationYear { get; set; }

        [Display(Name = "Month")]
        public int CreationMonth { get; set; }

        [Display(Name = "Day")]
        public int CreationDay { get; set; }

        [Display(Name = "City")]
        public string OriginCity { get; set; }

        [Display(Name = "State")]
        public string OriginState { get; set; }

        [Display(Name = "Country")]
        public string OriginCountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }

        [Display(Name = "Units")]
        public string UnitOfMeasureId { get; set; }
        public IEnumerable<SelectListItem> UnitsOfMeasure { get; set; }

        [Display(Name = "Estimated Value")]
        [DataType(DataType.Currency)]
        public decimal? EstimatedValue { get; set; }

        // Medium - Existing
        [Display(Name = "Medium")]
        public string MediumId { get; set; }
        public IEnumerable<SelectListItem> Media { get; set; }

        // Medium - New
        [Display(Name = "Medium")]
        public string MediumName { get; set; }

        // Genre - Existing
        [Display(Name = "Genre")]
        public string GenreId { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

        // Genre - New
        [Display(Name = "Genre")]
        public string GenreName { get; set; }

        // Subgenre - Existing
        [Display(Name = "Subgenre")]
        public string SubgenreId { get; set; }
        public IEnumerable<SelectListItem> Subgenres { get; set; }

        // Subgenre - New
        [Display(Name = "Subgenre")]
        public string SubgenreName { get; set; }

        // Subject Matter - Existing
        [Display(Name = "Subject Matter")]
        public string SubjectMatterId { get; set; }
        public IEnumerable<SelectListItem> SubjectMatters { get; set; }

        // Subject Matter - New
        [Display(Name = "Subject Matter")]
        public string SubjectMatterName { get; set; }

        [Display(Name = "Year")]
        public int CopyrightYear { get; set; }

        [Display(Name = "Owner")]
        public string CopyrightOwner { get; set; }

        // Artist Info
        [Display(Name = "Artist")]
        public string ArtistKnownAs { get; set; }
        public IEnumerable<SelectListItem> KnownArtists { get; set; }

        // Acquisition - Existing
        public string Acquisition { get; set; }
        public IEnumerable<SelectListItem> Acquisitions { get; set; }

        #region Acquisition - New
        [Display(Name = "Acquisition Date")]
        [DataType(DataType.Date)]
        public DateTime AcquisitionDate { get; set; }

        // Acquisition Location - Existing
        [Display(Name = "Location")]
        public string AcquisitionLocationId { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }

        // Acquisition Location - New
        [Display(Name = "Name")]
        public string AcquisitionLocationName { get; set; }

        [Display(Name = "Address Line 1")]
        public string AcquisitionAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AcquisitionAddress2 { get; set; }

        [Display(Name = "City")]
        public string AcquisitionCity { get; set; }

        [Display(Name = "State")]
        public string AcquisitionState { get; set; }

        [Display(Name = "Zip Code")]
        public string AcquisitionZipCode { get; set; }

        [Display(Name = "Country")]
        public string AcquisitionCountryId { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Cost { get; set; }

        public string Terms { get; set; }

        // Acquisition Funding Source - Existing
        [Display(Name = "Funding Source")]
        public string FundingSourceId { get; set; }
        public IEnumerable<SelectListItem> FundingSources { get; set; }

        // Acquisition Funding Source - New
        [Display(Name = "Funding Source")]
        public string FundingSourceName { get; set; }

        // Acquisition Piece Source - Existing
        [Display(Name = "Source")]
        public string PieceSourceId { get; set; }
        public IEnumerable<SelectListItem> PieceSources { get; set; }

        // Acquisition Piece Source - New
        [Display(Name = "Source")]
        public string PieceSourceName { get; set; }
        #endregion

        // Insurance - Existing
        [Display(Name = "Policy Number")]
        public string InsurancePolicyId { get; set; }
        public IEnumerable<SelectListItem> InsurancePolicies { get; set; }

        // Insurance - New
        public string PolicyNumber { get; set; }
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }
        [Display(Name = "Amount Insured")]
        public decimal AmountInsured { get; set; }
        public string Carrier { get; set; }

        [Display(Name = "Framed")]
        public bool IsFramed { get; set; }
    }
}
