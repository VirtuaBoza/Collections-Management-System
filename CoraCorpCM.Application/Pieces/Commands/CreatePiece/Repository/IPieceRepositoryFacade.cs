using System.Linq;
using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.Pieces.Commands.CreatePiece.Repository
{
    public interface IPieceRepositoryFacade
    {
        Country GetCountry(int id);
        UnitOfMeasure GetUnitOfMeasure(int id);
        Artist GetArtist(int id);
        void AddArtist(Artist artist);
        Medium GetMedium(int id);
        IQueryable<Medium> GetMedia();
        void AddMedium(Medium medium);
        Genre GetGenre(int id);
        IQueryable<Genre> GetGenres();
        void AddGenre(Genre genre);
        Subgenre GetSubgenre(int id);
        IQueryable<Subgenre> GetSubgenres();
        void AddSubgenre(Subgenre subgenre);
        SubjectMatter GetSubjectMatter(int id);
        IQueryable<SubjectMatter> GetSubjectMatters();
        void AddSubjectMatter(SubjectMatter subjectMatter);
        Acquisition GetAcquisition(int id);
        void AddAcquisition(Acquisition acquisition);
        IQueryable<FundingSource> GetFundingSources();
        void AddFundingSource(FundingSource fundingSource);
        FundingSource GetFundingSource(int id);
        PieceSource GetPieceSource(int id);
        IQueryable<PieceSource> GetPieceSources();
        void AddPieceSource(PieceSource pieceSource);
        Location GetLocation(int id);
        void AddLocation(Location location);
        Collection GetCollection(int id);
        IQueryable<Collection> GetCollections();
        void AddCollection(Collection collection);
        void AddPiece(Piece piece);
        Museum GetMuseum(int id);
    }
}
