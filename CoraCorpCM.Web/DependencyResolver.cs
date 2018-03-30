using CoraCorpCM.App.Acquisitions.Queries.GetAcquisitionList;
using CoraCorpCM.App.Artists.Queries.GetArtistList;
using CoraCorpCM.App.Collections.Queries.GetCollectionList;
using CoraCorpCM.App.Countries.Queries;
using CoraCorpCM.App.Countries.Queries.GetCountry;
using CoraCorpCM.App.FundingSources.Queries.GetFundingSourceList;
using CoraCorpCM.App.Genres.Queries.GetGenreList;
using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.App.Locations.Queries.GetLocationList;
using CoraCorpCM.App.Media.Queries.GetMediumList;
using CoraCorpCM.App.Museums.Commands.RegisterMuseum.Factory;
using CoraCorpCM.App.Museums.Commands.RemoveMuseum;
using CoraCorpCM.App.Museums.Queries;
using CoraCorpCM.App.Pieces.Commands.RemovePiece;
using CoraCorpCM.App.Pieces.Queries;
using CoraCorpCM.App.PieceSources.Queries.GetPieceSourceList;
using CoraCorpCM.App.Subgenres.Queries.GetSubgenreList;
using CoraCorpCM.App.SubjectMatters.Queries.GetSubjectMatterList;
using CoraCorpCM.App.UnitsOfMeasure.Queries.GetUnitsOfMeasureList;
using CoraCorpCM.App.Users.Commands.RegisterUser.Factory;
using CoraCorpCM.Data.Acquisitions;
using CoraCorpCM.Data.Artists;
using CoraCorpCM.Data.Collections;
using CoraCorpCM.Data.Countries;
using CoraCorpCM.Data.FundingSources;
using CoraCorpCM.Data.Genres;
using CoraCorpCM.Data.Locations;
using CoraCorpCM.Data.Media;
using CoraCorpCM.Data.Museums;
using CoraCorpCM.Data.Pieces;
using CoraCorpCM.Data.PieceSources;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Data.Subgenres;
using CoraCorpCM.Data.SubjectMatters;
using CoraCorpCM.Data.UnitsOfMeasure;
using CoraCorpCM.Web.Services;
using CoraCorpCM.Web.Services.Account;
using CoraCorpCM.Web.Services.Collection;
using Microsoft.Extensions.DependencyInjection;

namespace CoraCorpCM.Web
{
    public class DependencyResolver
    {
        public static void Resolve(IServiceCollection services)
        {
            services.AddScoped<IMuseumFactory, MuseumFactory>();

            services.AddScoped<ICreatePieceViewModelFactory, CreatePieceViewModelFactory>();
            services.AddScoped<IRegisterViewModelFactory, RegisterViewModelFactory>();
            services.AddScoped<IGetCountryListQuery, GetCountryListQuery>();
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IGetUnitOfMeasureListQuery, GetUnitOfMeasureListQuery>();
            services.AddScoped<IGetSubjectMatterListQuery, GetSubjectMatterListQuery>();
            services.AddScoped<IGetSubgenreListQuery, GetSubgenreListQuery>();
            services.AddScoped<IGetPieceSourceListQuery, GetPieceSourceListQuery>();
            //services.AddScoped<ICreatePieceCommand,>
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

            // Persistence
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

            services.AddSingleton<IEmailSender, SendGridEmailSender>();
        }
    }
}
