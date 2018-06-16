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
    public class CreatePieceCommandFacade : ICreatePieceCommandFacade
    {
        private readonly ICreateAcquisitionCommand createAcquisitionCommand;
        private readonly ICreateArtistCommand createArtistCommand;
        private readonly ICreateCollectionCommand createCollectionCommand;
        private readonly ICreateFundingSourceCommand createFundingSourceCommand;
        private readonly ICreateGenreCommand createGenreCommand;
        private readonly ICreateLocationCommand createLocationCommand;
        private readonly ICreateMediumCommand createMediumCommand;
        private readonly ICreatePieceCommand createPieceCommand;
        private readonly ICreatePieceSourceCommand createPieceSourceCommand;
        private readonly ICreateSubgenreCommand createSubgenreCommand;
        private readonly ICreateSubjectMatterCommand createSubjectMatterCommand;

        public CreatePieceCommandFacade(
            ICreateAcquisitionCommand createAcquisitionCommand,
            ICreateArtistCommand createArtistCommand,
            ICreateCollectionCommand createCollectionCommand,
            ICreateFundingSourceCommand createFundingSourceCommand,
            ICreateGenreCommand createGenreCommand,
            ICreateLocationCommand createLocationCommand,
            ICreateMediumCommand createMediumCommand,
            ICreatePieceCommand createPieceCommand,
            ICreatePieceSourceCommand createPieceSourceCommand,
            ICreateSubgenreCommand createSubgenreCommand,
            ICreateSubjectMatterCommand createSubjectMatterCommand)
        {
            this.createAcquisitionCommand = createAcquisitionCommand;
            this.createArtistCommand = createArtistCommand;
            this.createCollectionCommand = createCollectionCommand;
            this.createFundingSourceCommand = createFundingSourceCommand;
            this.createGenreCommand = createGenreCommand;
            this.createLocationCommand = createLocationCommand;
            this.createMediumCommand = createMediumCommand;
            this.createPieceCommand = createPieceCommand;
            this.createPieceSourceCommand = createPieceSourceCommand;
            this.createSubgenreCommand = createSubgenreCommand;
            this.createSubjectMatterCommand = createSubjectMatterCommand;
        }

        public int Execute(CreateAcquisitionModel acquisitionModel)
        {
            return createAcquisitionCommand.Execute(acquisitionModel);
        }

        public int Execute(CreateArtistModel artistModel)
        {
            return createArtistCommand.Execute(artistModel);
        }

        public int Execute(CreateCollectionModel collectionModel)
        {
            return createCollectionCommand.Execute(collectionModel);
        }

        public int Execute(CreateFundingSourceModel fundingSourceModel)
        {
            return createFundingSourceCommand.Execute(fundingSourceModel);
        }

        public int Execute(CreateGenreModel genreModel)
        {
            return createGenreCommand.Execute(genreModel);
        }

        public int Execute(CreateLocationModel locationModel)
        {
            return createLocationCommand.Execute(locationModel);
        }

        public int Execute(CreateMediumModel mediumModel)
        {
            return createMediumCommand.Execute(mediumModel);
        }

        public int Execute(CreatePieceModel pieceModel)
        {
            return createPieceCommand.Execute(pieceModel);
        }

        public int Execute(CreatePieceSourceModel pieceSourceModel)
        {
            return createPieceSourceCommand.Execute(pieceSourceModel);
        }

        public int Execute(CreateSubgenreModel subgenreModel)
        {
            return createSubgenreCommand.Execute(subgenreModel);
        }

        public int Execute(CreateSubjectMatterModel subjectMatterModel)
        {
            return createSubjectMatterCommand.Execute(subjectMatterModel);
        }
    }
}
