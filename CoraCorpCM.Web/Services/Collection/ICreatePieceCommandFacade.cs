using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition;
using CoraCorpCM.Application.Artists.Commands.CreateArtist;
using CoraCorpCM.Application.Collections.Commands.CreateCollection;
using CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource;
using CoraCorpCM.Application.Genres.Commands.CreateGenre;
using CoraCorpCM.Application.Locations.Commands.CreateLocation;
using CoraCorpCM.Application.Media.Commands.CreateMedium;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource;
using CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre;
using CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter;

namespace CoraCorpCM.Web.Services.Collection
{
    public interface ICreatePieceCommandFacade
    {
        int Execute(CreateAcquisitionModel acquisitionModel);
        int Execute(CreateArtistModel artistModel);
        int Execute(CreateCollectionModel collectionModel);
        int Execute(CreateFundingSourceModel fundingSourceModel);
        int Execute(CreateGenreModel genreModel);
        int Execute(CreateLocationModel locationModel);
        int Execute(CreateMediumModel mediumModel);
        int Execute(CreatePieceModel pieceModel);
        int Execute(CreatePieceSourceModel pieceSourceModel);
        int Execute(CreateSubgenreModel subgenreModel);
        int Execute(CreateSubjectMatterModel subjectMatterModel);
    }
}