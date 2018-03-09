using System.Collections.Generic;
using System.Threading.Tasks;
using CoraCorpCM.Domain.Models;

namespace CoraCorpCM.Data
{
    public interface IMuseumRepository
    {
        TEntity GetEntity<TEntity>(int id) where TEntity : class, IEntity;

        #region Acquisition
        IEnumerable<Acquisition> GetAcquisitions(Museum museum);
        #endregion

        #region Artist
        Artist GetArtist(int id);
        IEnumerable<Artist> GetArtists(Museum museum);
        #endregion

        #region Collection
        int AddCollection(Collection collection);

        Collection GetCollection(int id);
        IEnumerable<Collection> GetCollections(Museum museum);
        #endregion

        #region Country
        Country GetCountry(int id);
        Country GetFirstCountry();
        IEnumerable<Country> GetCountries();
        #endregion

        #region Funding Source
        FundingSource GetFundingSource(int id);
        IEnumerable<FundingSource> GetFundingSources(Museum museum);
        #endregion

        #region Genre
        int AddGenre(Genre genre);

        Genre GetGenre(int id);
        IEnumerable<Genre> GetGenres(Museum museum);
        #endregion

        #region Location
        // Create
        int AddLocation(Location location);

        Location GetLocation(int id);
        IEnumerable<Location> GetLocations(Museum museum);
        #endregion

        #region Medium
        // Create
        int AddMedium(Medium medium);

        Medium GetMedium(int id);
        IEnumerable<Medium> GetMedia(Museum museum);
        #endregion

        #region Museum
        // Create
        int AddMuseum(Museum museum);

        // Read
        Museum GetMuseum(ApplicationUser user);
        #endregion

        #region Piece
        // Create
        int AddPiece(Piece piece);

        // Read
        IEnumerable<Piece> GetPieces(Museum museum);
        bool PieceExists(int id);
        Piece GetPiece(int? id);

        // Update
        Task<int> UpdatePiece(Piece piece);

        // Delete
        Task<int> DeletePiece(int id);
        #endregion

        #region Piece Source
        PieceSource GetPieceSource(int id);
        IEnumerable<PieceSource> GetPieceSources(Museum museum);
        #endregion

        #region Subgenre
        int AddSubgenre(Subgenre subgenre);

        Subgenre GetSubgenre(int id);
        IEnumerable<Subgenre> GetSubgenres(Museum museum);
        #endregion

        #region Subject Matter
        int AddSubjectMatter(SubjectMatter subjectMatter);

        SubjectMatter GetSubjectMatter(int id);
        IEnumerable<SubjectMatter> GetSubjectMatters(Museum museum);
        #endregion

        #region Unit Of Measure
        UnitOfMeasure GetUnitOfMeasure(int id);
        IEnumerable<UnitOfMeasure> GetUnitsOfMeasure();
        #endregion
    }
}