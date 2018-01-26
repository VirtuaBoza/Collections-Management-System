using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CoraCorpCM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoraCorpCM.Data
{
    public interface IMuseumRepository
    {
        #region Acquisition
        IEnumerable<SelectListItem> GetAcquisitionSelections(Museum museum);
        #endregion

        #region Artist
        Task<Artist> GetArtist(int id);

        IEnumerable<SelectListItem> GetArtistSelections(Museum museum);
        #endregion

        #region Country
        Country GetCountry(int id);
        Country GetFirstCountry();
        IEnumerable<SelectListItem> GetCountrySelections();
        #endregion

        #region Funding Source
        IEnumerable<SelectListItem> GetFundingSourceSelections(Museum museum);
        #endregion

        #region Genre
        IEnumerable<SelectListItem> GetGenreSelections(Museum museum);
        #endregion

        #region Location
        // Create
        Location CreateLocation(string name, string address1, string address2, string city, string state, string zipCode, Country country, Museum museum);
        
        // Read
        IEnumerable<SelectListItem> GetLocationSelections(Museum museum);
        #endregion

        #region Medium
        // Create
        Medium CreateMedium(string name, Museum museum);

        // Read
        IEnumerable<SelectListItem> GetMediumSelections(Museum museum);
        #endregion

        #region Museum
        // Create
        Museum CreateMuseum(string name, string shortname,
            string address1, string address2, string city, string state, string zipCode, Country country,
            ApplicationUser creator);

        // Read
        Museum GetMuseum(ApplicationUser user);
        #endregion

        #region Piece
        // Create
        Task<int> CreatePiece(
            string accessionNumber,
            Artist artist,
            string title,
            int creationDay,
            int creationMonth,
            int creationYear,
            Country countryOfOrigin,
            string stateOfOrigin,
            string cityOfOrigin,
            double height,
            double width,
            double depth,
            UnitOfMeasure unitOfMeasure,
            decimal estimatedValue,
            Medium medium,
            Genre genre,
            Subgenre subgenre,
            string subject,
            SubjectMatter subjectMatter,
            int copyrightYear,
            string copyrightOwner,
            Acquisition acquisition,
            string policyNumber,
            DateTime expiration,
            decimal amountInsured,
            string carrier,
            bool isFramed,
            Location currentLocation,
            Location permanentLocation,
            Collection collection,
            ApplicationUser user,
            Museum museum);

        Task<int> CreatePiece(Piece piece);

        // Read
        Task<List<Piece>> GetAllPiecesForMuseum(Museum museum);
        bool PieceExists(int id);
        Task<Piece> GetPiece(int? id);

        // Update
        Task<int> UpdatePiece(Piece piece);

        // Delete
        Task<int> DeletePiece(int id);
        #endregion

        #region Piece Source
        IEnumerable<SelectListItem> GetPieceSourceSelections(Museum museum);
        #endregion

        #region Subgenre
        IEnumerable<SelectListItem> GetSubgenreSelections(Museum museum);
        #endregion

        #region Subject Matter
        IEnumerable<SelectListItem> GetSubjectMatterSelections(Museum museum);
        #endregion

        #region Unit Of Measure
        IEnumerable<SelectListItem> GetUnitOfMeasureSelections();
        #endregion
    }
}