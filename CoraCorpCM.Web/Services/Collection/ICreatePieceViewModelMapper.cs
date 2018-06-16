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
using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Services.Collection
{
    public interface ICreatePieceViewModelMapper
    {
        CreateLocationModel MapCurrentLocationToCreateLocationModel(CreatePieceViewModel model, int museumId);
        CreateLocationModel MapPermanentLocationToCreateLocationModel(CreatePieceViewModel model, int museumId);
        CreateAcquisitionModel MapToCreateAcquisitionModel(CreatePieceViewModel model, int museumId);
        CreateArtistModel MapToCreateArtistModel(CreatePieceViewModel model, int museumId);
        CreateCollectionModel MapToCreateCollectionModel(CreatePieceViewModel model, int museumId);
        CreateFundingSourceModel MapToCreateFundingSourceModel(CreatePieceViewModel model, int museumId);
        CreateGenreModel MapToCreateGenreModel(CreatePieceViewModel model, int museumId);
        CreateMediumModel MapToCreateMediumModel(CreatePieceViewModel model, int museumId);
        CreatePieceModel MapToCreatePieceModel(CreatePieceViewModel model, int museumId, string userId);
        CreatePieceSourceModel MapToCreatePieceSourceModel(CreatePieceViewModel model, int museumId);
        CreateSubgenreModel MapToCreateSubgenreModel(CreatePieceViewModel model, int museumId);
        CreateSubjectMatterModel MapToCreateSubjectMatterModel(CreatePieceViewModel model, int museumId);
    }
}