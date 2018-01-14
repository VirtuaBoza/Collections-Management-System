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

        #region Insurance Policy
        IEnumerable<SelectListItem> GetInsurancePolicySelections(Museum museum);
        #endregion

        #region Location
        IEnumerable<SelectListItem> GetLocationSelections(Museum museum);
        #endregion

        #region Medium
        IEnumerable<SelectListItem> GetMediumSelections(Museum museum);
        #endregion

        #region Museum
        // Create
        Museum CreateMuseum(string name, string shortname,
            string address1, string address2, string city, string state, string zipCode, Country country,
            ApplicationUser creator);

        // Read
        Museum GetMuseum(ApplicationUser user);
        Museum GetMuseum(ClaimsPrincipal principal);
        #endregion

        #region Piece
        // Create
        Task<int> CreatePieceForMuseum(Piece piece, Museum museum);

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