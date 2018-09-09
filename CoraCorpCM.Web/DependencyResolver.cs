using CoraCorpCM.Application.Acquisitions.Queries.GetAcquisitionList;
using CoraCorpCM.Application.Artists.Commands.CreateArtist.Factory;
using CoraCorpCM.Application.Artists.Queries.GetArtistList;
using CoraCorpCM.Application.Collections.Commands.CreateCollection.Factory;
using CoraCorpCM.Application.Collections.Queries.GetCollectionList;
using CoraCorpCM.Application.Countries.Queries;
using CoraCorpCM.Application.Countries.Queries.GetCountry;
using CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource.Factory;
using CoraCorpCM.Application.FundingSources.Queries.GetFundingSourceList;
using CoraCorpCM.Application.Genres.Commands.CreateGenre.Factory;
using CoraCorpCM.Application.Genres.Queries.GetGenreList;
using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Interfaces.Infrastructure;
using CoraCorpCM.Application.Locations.Commands.CreateLocation.Factory;
using CoraCorpCM.Application.Locations.Queries.GetLocationList;
using CoraCorpCM.Application.Media.Commands.CreateMedium.Factory;
using CoraCorpCM.Application.Media.Queries.GetMediumList;
using CoraCorpCM.Application.Museums.Commands.CreateMuseum.Factory;
using CoraCorpCM.Application.Museums.Commands.RemoveMuseum;
using CoraCorpCM.Application.Museums.Queries;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece.Factory;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece.Repository;
using CoraCorpCM.Application.Pieces.Commands.RemovePiece;
using CoraCorpCM.Application.Pieces.Queries;
using CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource.Factory;
using CoraCorpCM.Application.PieceSources.Queries.GetPieceSourceList;
using CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre.Factory;
using CoraCorpCM.Application.Subgenres.Queries.GetSubgenreList;
using CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter.Factory;
using CoraCorpCM.Application.SubjectMatters.Queries.GetSubjectMatterList;
using CoraCorpCM.Application.UnitsOfMeasure.Queries.GetUnitsOfMeasureList;
using CoraCorpCM.Common.Membership;
using CoraCorpCM.Infrastructure.Persistence.Repositories;
using CoraCorpCM.Infrastructure.Services.Email;
using CoraCorpCM.Web.Services.Account;
using CoraCorpCM.Web.Services.Collection;
using Microsoft.Extensions.DependencyInjection;
using CoraCorpCM.Web.Services.Shared;
using CoraCorpCM.Application.Artists.Commands.CreateArtist;
using CoraCorpCM.Application.Collections.Commands.CreateCollection;
using CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource;
using CoraCorpCM.Application.Genres.Commands.CreateGenre;
using CoraCorpCM.Application.Locations.Commands.CreateLocation;
using CoraCorpCM.Application.Media.Commands.CreateMedium;
using CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource;
using CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre;
using CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter;
using CoraCorpCM.Infrastructure.Persistence.Contexts;
using CoraCorpCM.Infrastructure.Services;
using CoraCorpCM.Web.Mappers;

namespace CoraCorpCM.Web
{
    public class DependencyResolver
    {
        public static void Resolve(IServiceCollection services)
        {
            // Implemented by Application
            services.AddScoped<IMuseumFactory, MuseumFactory>();
            services.AddScoped<ICreateArtistCommand, CreateArtistCommand>();
            services.AddScoped<ICreateCollectionCommand, CreateCollectionCommand>();
            services.AddScoped<ICreateFundingSourceCommand, CreateFundingSourceCommand>();
            services.AddScoped<ICreateGenreCommand, CreateGenreCommand>();
            services.AddScoped<ICreateLocationCommand, CreateLocationCommand>();
            services.AddScoped<ICreateMediumCommand, CreateMediumCommand>();
            services.AddScoped<ICreatePieceSourceCommand, CreatePieceSourceCommand>();
            services.AddScoped<ICreateSubgenreCommand, CreateSubgenreCommand>();
            services.AddScoped<ICreateSubjectMatterCommand, CreateSubjectMatterCommand>();

            // Implemented by Web
            services.AddScoped<ICreatePieceViewModelFactory, CreatePieceViewModelFactory>();
            services.AddScoped<IRegisterViewModelFactory, RegisterViewModelFactory>();
            services.AddScoped<IGetCountryListQuery, GetCountryListQuery>();
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IGetUnitOfMeasureListQuery, GetUnitOfMeasureListQuery>();
            services.AddScoped<IGetSubjectMatterListQuery, GetSubjectMatterListQuery>();
            services.AddScoped<IGetSubgenreListQuery, GetSubgenreListQuery>();
            services.AddScoped<IGetPieceSourceListQuery, GetPieceSourceListQuery>();
            services.AddScoped<ICreatePieceCommand, CreatePieceCommand>();
            services.AddScoped<IGetPieceQuery, GetPieceQuery>();
            services.AddScoped<IGetPieceListQuery, GetPieceListQuery>();
            services.AddScoped<IRemovePieceCommand, RemovePieceCommand>();
            services.AddScoped<IGetMuseumForUserIdQuery, GetMuseumForUserIdQuery>();
            services.AddScoped<IRemoveMuseumCommand, RemoveMuseumCommand>();
            services.AddScoped<IGetMediumListQuery, GetMediumListQuery>();
            services.AddScoped<IGetLocationListQuery, GetLocationListQuery>();
            services.AddScoped<IGetGenreListQuery, GetGenreListQuery>();
            services.AddScoped<IGetFundingSourceListQuery, GetFundingSourceListQuery>();
            services.AddScoped<IGetCountryQuery, GetCountryQuery>();
            services.AddScoped<IGetCollectionListQuery, GetCollectionListQuery>();
            services.AddScoped<IGetArtistListQuery, GetArtistListQuery>();
            services.AddScoped<IGetAcquisitionListQuery, GetAcquisitionListQuery>();
            services.AddScoped<IPieceRepositoryFacade, PieceRepositoryFacade>();
            services.AddScoped<IPieceFactory, PieceFactory>();
            services.AddScoped<IArtistFactory, ArtistFactory>();
            services.AddScoped<IMediumFactory, MediumFactory>();
            services.AddScoped<IGenreFactory, GenreFactory>();
            services.AddScoped<ISubgenreFactory, SubgenreFactory>();
            services.AddScoped<ISubjectMatterFactory, SubjectMatterFactory>();
            services.AddScoped<IFundingSourceFactory, FundingSourceFactory>();
            services.AddScoped<IPieceSourceFactory, PieceSourceFactory>();
            services.AddScoped<ILocationFactory, LocationFactory>();
            services.AddScoped<ICollectionFactory, CollectionFactory>();
            services.AddScoped<ICallbackUrlCreator, CallbackUrlCreator>();
            services.AddScoped<ICreatePieceMapper, CreatePieceMapper>();

            // Implemented by Persistence
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
            services.AddScoped<ISubjectMatterRepository, SubjectMatterRepository>();
            services.AddScoped<ISubgenreRepository, SubgenreRepository>();
            services.AddScoped<IPieceSourceRepository, PieceSourceRepository>();
            services.AddScoped<IPieceRepository, PieceRepository>();
            services.AddScoped<IMuseumRepository, MuseumRepository>();
            services.AddScoped<IMediumRepository, MediumRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IFundingSourceRepository, FundingSourceRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IAcquisitionRepository, AcquisitionRepository>();

            // Implemented by Infrastructure
            services.AddSingleton<IEmailSender, SendGridEmailSender>();

            // Implemented by Common
            services.AddSingleton<IDateTimeService, DateTimeService>();
        }
    }
}
