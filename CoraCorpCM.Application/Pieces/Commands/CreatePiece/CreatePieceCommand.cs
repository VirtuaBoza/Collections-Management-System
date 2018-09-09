using CoraCorpCM.Application.Interfaces.Infrastructure;
using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece.Repository;

namespace CoraCorpCM.Application.Pieces.Commands.CreatePiece
{
    public class CreatePieceCommand : ICreatePieceCommand
    {
        private readonly IPieceRepositoryFacade repository;
        private readonly IDateTimeService dateTimeService;
        private readonly IUnitOfWork unitOfWork;

        public CreatePieceCommand(
            IPieceRepositoryFacade repository,
            IDateTimeService dateTimeService,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.dateTimeService = dateTimeService;
            this.unitOfWork = unitOfWork;
        }

        public int Execute(CreatePieceModel model)
        {
            Country countryOfOrigin = null;
            if (model.CountryOfOriginId.HasValue)
            {
                countryOfOrigin = repository.GetCountry(model.CountryOfOriginId.Value);
            }

            var museum = repository.GetMuseum(model.MuseumId);
            var unitOfMeasure = repository.GetUnitOfMeasure(model.UnitOfMeasureId);
            var artist = GetArtist(model);
            var medium = GetMedium(model);
            var genre = GetGenre(model);
            var subgenre = GetSubgenre(model);
            var subjectMatter = GetSubjectMatter(model);
            var acquisition = GetAcquisition(model);
            var currentLocation = GetCurrentLocation(model);
            var permanentLocation = GetPermanentLocation(model);
            var collection = GetCollection(model);

            var piece = new Piece
                {
                    RecordNumber = ++museum.RecordCount,
                    Title = model.Title,
                    AccessionNumber = model.AccessionNumber,
                    CreationDay = model.CreationDay,
                    CreationMonth = model.CreationMonth,
                    CreationYear = model.CreationYear,
                    CountryOfOrigin = countryOfOrigin,
                    StateOfOrigin = model.StateOfOrigin,
                    CityOfOrigin = model.CityOfOrigin,
                    Height = model.Height,
                    Width = model.Width,
                    Depth = model.Depth,
                    UnitOfMeasure = unitOfMeasure,
                    EstimatedValue = model.EstimatedValue,
                    Subject = model.Subject,
                    CopyrightYear = model.CopyrightYear,
                    CopyrightOwner = model.CopyrightOwner,
                    InsurancePolicyNumber = model.InsurancePolicyNumber,
                    InsuranceExpirationDate = model.InsuranceExpirationDate,
                    InsuranceAmount = model.InsuranceAmount,
                    InsuranceCarrier = model.InsuranceCarrier,
                    IsFramed = model.IsFramed,
                    IsArchived = model.IsArchived,
                    Artist = artist,
                    Medium = medium,
                    Genre = genre,
                    Subgenre = subgenre,
                    SubjectMatter = subjectMatter,
                    Acquisition = acquisition,
                    CurrentLocation = currentLocation,
                    PermanentLocation = permanentLocation,
                    Collection = collection,
                    ApplicationUserId = model.LastModifiedByUserId,
                    LastModified = dateTimeService.GetTimeUtc(),
                    MuseumId = model.MuseumId
                };

            repository.AddPiece(piece);

            unitOfWork.SaveChanges();

            return piece.Id;
        }

        private Artist GetArtist(CreatePieceModel model)
        {
            if (model.ArtistId.HasValue)
            {
                if (model.ArtistId >= 0)
                {
                    return repository.GetArtist(model.ArtistId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.ArtistName))
                {
                    return new Artist
                    {
                        Name = model.ArtistName,
                        AlsoKnownAs = model.ArtistAlsoKnownAs,
                        StateOfOrigin = model.ArtistStateOfOrigin,
                        CityOfOrigin = model.ArtistCityOfOrigin,
                        CountryOfOrigin = model.ArtistCountryOfOriginId.HasValue ? 
                            repository.GetCountry(model.ArtistCountryOfOriginId.Value) : null,
                        Birthdate = model.ArtistBirthDate,
                        Deathdate = model.ArtistDeathDate,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }

        private Medium GetMedium(CreatePieceModel model)
        {
            if (model.MediumId.HasValue)
            {
                if (model.MediumId >= 0)
                {
                    return repository.GetMedium(model.MediumId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.MediumName))
                {
                    return new Medium
                    {
                        Name = model.MediumName,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }

        private Genre GetGenre(CreatePieceModel model)
        {
            if (model.GenreId.HasValue)
            {
                if (model.GenreId >= 0)
                {
                    return repository.GetGenre(model.GenreId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.GenreName))
                {
                    return new Genre
                    {
                        Name = model.GenreName,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }

        private Subgenre GetSubgenre(CreatePieceModel model)
        {
            if (model.SubgenreId.HasValue)
            {
                if (model.SubgenreId >= 0)
                {
                    return repository.GetSubgenre(model.SubgenreId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.SubgenreName))
                {
                    return new Subgenre
                    {
                        Name = model.SubgenreName,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }

        private SubjectMatter GetSubjectMatter(CreatePieceModel model)
        {
            if (model.SubjectMatterId.HasValue)
            {
                if (model.SubjectMatterId >= 0)
                {
                    return repository.GetSubjectMatter(model.SubjectMatterId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.SubjectMatterName))
                {
                    return new SubjectMatter
                    {
                        Name = model.SubjectMatterName,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }

        private Acquisition GetAcquisition(CreatePieceModel model)
        {
            if (model.AcquisitionId.HasValue)
            {
                if (model.AcquisitionId >= 0)
                {
                    return repository.GetAcquisition(model.AcquisitionId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.PieceSourceName) || 
                    model.PieceSourceId >= 0 ||
                     model.AcquisitionDate.HasValue)
                {
                    return new Acquisition
                    {
                        Date = model.AcquisitionDate,
                        PieceSource = model.PieceSourceId.HasValue ? 
                            repository.GetPieceSource(model.PieceSourceId.Value) : !string.IsNullOrWhiteSpace(model.PieceSourceName) ?
                                new PieceSource { Name = model.PieceSourceName, MuseumId = model.MuseumId } : null,
                        Cost = model.AcquisitionCost,
                        FundingSource = model.FundingSourceId.HasValue ? 
                            repository.GetFundingSource(model.FundingSourceId.Value) : !string.IsNullOrWhiteSpace(model.FundingSourceName) ?
                                new FundingSource { Name = model.FundingSourceName, MuseumId = model.MuseumId } : null,
                        Terms = model.AcquisitionTerms,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }

        private Location GetCurrentLocation(CreatePieceModel model)
        {
            if (model.CurrentLocationId.HasValue)
            {
                if (model.CurrentLocationId >= 0)
                {
                    return repository.GetLocation(model.CurrentLocationId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.CurrentLocationName))
                {
                    return new Location
                    {
                        Name = model.CurrentLocationName,
                        Address1 = model.CurrentLocationAddress1,
                        Address2 = model.CurrentLocationAddress2,
                        City = model.CurrentLocationCity,
                        Country = model.CurrentLocationCountryId.HasValue ? repository.GetCountry(model.CurrentLocationCountryId.Value) : null,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }

        private Location GetPermanentLocation(CreatePieceModel model)
        {
            if (model.PermanentLocationId.HasValue)
            {
                if (model.PermanentLocationId >= 0)
                {
                    return repository.GetLocation(model.PermanentLocationId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.PermanentLocationName))
                {
                    return new Location
                    {
                        Name = model.PermanentLocationName,
                        Address1 = model.PermanentLocationAddress1,
                        Address2 = model.PermanentLocationAddress2,
                        City = model.PermanentLocationCity,
                        Country = model.PermanentLocationCountryId.HasValue ? repository.GetCountry(model.PermanentLocationCountryId.Value) : null,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }

        private Collection GetCollection(CreatePieceModel model)
        {
            if (model.CollectionId.HasValue)
            {
                if (model.CollectionId >= 0)
                {
                    return repository.GetCollection(model.CollectionId.Value);
                }

                if (!string.IsNullOrWhiteSpace(model.CollectionName))
                {
                    return new Collection
                    {
                        Name = model.CollectionName,
                        MuseumId = model.MuseumId
                    };
                }
            }

            return null;
        }
    }
}
