using CoraCorpCM.Data;
using CoraCorpCM.Domain.Models;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using System;

namespace CoraCorpCM.Web.Utilities
{
    public class ModelMapper : IModelMapper
    {
        private readonly IMuseumRepository museumRepository;

        public ModelMapper (IMuseumRepository museumRepository)
        {
            this.museumRepository = museumRepository;
        }

        public Piece ResolveToPieceModel(PieceViewModel model, ApplicationUser user)
        {
            var userMuseum = museumRepository.GetMuseum(user);

            var piece = new Piece
            {
                Title = model.Title,
                Museum = userMuseum,
                AccessionNumber = model.AccessionNumber,
                StateOfOrigin = model.OriginState,
                CityOfOrigin = model.OriginCity,
                Height = model.Height,
                Width = model.Width,
                Depth = model.Depth,
                EstimatedValue = model.EstimatedValue,
                Subject = model.Subject,
                CopyrightOwner = model.CopyrightOwner,
                InsurancePolicyNumber = model.PolicyNumber,
                InsuranceAmount = model.AmountInsured,
                InsuranceCarrier = model.Carrier,
                IsFramed = model.IsFramed,
                LastModifiedBy = user,
                LastModified = DateTime.Now
            };

            // Creation day, month, year
            if (int.TryParse(model.CreationDay, out int creationDay))
            {
                piece.CreationDay = creationDay;
            }

            if (int.TryParse(model.CreationMonth, out int creationMonth))
            {
                piece.CreationMonth = creationMonth;
            }

            if (int.TryParse(model.CreationYear, out int creationYear))
            {
                piece.CreationYear = creationYear;
            }

            // Country of Origin
            if (int.TryParse(model.OriginCountryId, out int originCountryId))
            {
                piece.CountryOfOrigin = museumRepository.GetCountry(originCountryId);
            }

            piece.Artist = ResolveToArtist(model, userMuseum);

            if (int.TryParse(model.UnitOfMeasureId, out int unitOfMeasureId))
            {
                piece.UnitOfMeasure = museumRepository.GetUnitOfMeasure(unitOfMeasureId);
            }

            piece.Medium = ResolveToMedium(model, userMuseum);
            piece.Genre = ResolveToGenre(model, userMuseum);
            piece.Subgenre = ResolveToSubgenre(model, userMuseum);
            piece.SubjectMatter = ResolveToSubjectMatter(model, userMuseum);

            if (int.TryParse(model.CopyrightYear, out int copyrightYear))
            {
                piece.CopyrightYear = copyrightYear;
            }

            piece.Acquisition = ResolveToAcquisition(model, userMuseum);

            if (DateTime.TryParse(model.ExpirationDate, out DateTime expDate))
            {
                piece.InsuranceExpirationDate = expDate;
            }

            Location permanentLocation = null;
            if (int.TryParse(model.PermanentLocationId, out int permLocId))
            {
                if (permLocId == -1 && !string.IsNullOrWhiteSpace(model.PermanentLocationName))
                {
                    permanentLocation = new Location
                    {
                        Name = model.PermanentLocationName,
                        Address1 = model.PermanentAddress1,
                        Address2 = model.PermanentAddress2,
                        City = model.PermanentCity,
                        State = model.PermanentState,
                        ZipCode = model.PermanentZipCode
                    };
                    if (int.TryParse(model.PermanentCountryId, out int permCountry))
                    {
                        permanentLocation.Country = museumRepository.GetCountry(permCountry);
                    }
                }
                else
                {
                    permanentLocation = museumRepository.GetLocation(permLocId);
                }
            }
            piece.PermanentLocation = permanentLocation;

            Location currentLocation = null;
            if (int.TryParse(model.PermanentLocationId, out int currLocId))
            {
                if (currLocId == -1 && !string.IsNullOrWhiteSpace(model.CurrentLocationName))
                {
                    currentLocation = new Location
                    {
                        Name = model.CurrentLocationName,
                        Address1 = model.CurrentAddress1,
                        Address2 = model.CurrentAddress2,
                        City = model.CurrentCity,
                        State = model.CurrentState,
                        ZipCode = model.CurrentZipCode
                    };
                    if (int.TryParse(model.CurrentCountryId, out int currCountry))
                    {
                        currentLocation.Country = museumRepository.GetCountry(currCountry);
                    }
                }
                else
                {
                    currentLocation = museumRepository.GetLocation(currLocId);
                }
            }
            piece.PermanentLocation = currentLocation;

            piece.Collection = ResolveToCollection(model, userMuseum);

            return piece;
        }

        private Collection ResolveToCollection(PieceViewModel model, Museum museum)
        {
            Collection collection = null;
            if (int.TryParse(model.CollectionId, out int collId))
            {
                if (collId == -1 && !string.IsNullOrWhiteSpace(model.CollectionName))
                {
                    collection = new Collection
                    {
                        Name = model.CollectionName,
                        Museum = museum
                    };
                }
                else
                {
                    collection = museumRepository.GetCollection(collId);
                }
            }

            return collection;
        }

        private Medium ResolveToMedium(PieceViewModel model, Museum museum)
        {
            Medium medium = null;
            if(int.TryParse(model.MediumId, out int mediumId))
            {
                if (mediumId == -1 && !string.IsNullOrWhiteSpace(model.MediumName))
                {
                    medium = new Medium
                    {
                        Name = model.MediumName,
                        Museum = museum
                    };
                }
                else
                {
                    medium = museumRepository.GetMedium(mediumId);
                }
            }

            return medium;
        }

        private Genre ResolveToGenre(PieceViewModel model, Museum museum)
        {
            Genre genre = null;
            if (int.TryParse(model.GenreId, out int genreId))
            {
                if (genreId == -1 && !string.IsNullOrWhiteSpace(model.GenreName))
                {
                    genre = new Genre
                    {
                        Name = model.GenreName,
                        Museum = museum
                    };
                }
                else
                {
                    genre = museumRepository.GetGenre(genreId);
                }
            }

            return genre;
        }

        private Subgenre ResolveToSubgenre(PieceViewModel model, Museum museum)
        {
            Subgenre subgenre = null;
            if (int.TryParse(model.SubgenreId, out int subgenreId))
            {
                if (subgenreId == -1 && !string.IsNullOrWhiteSpace(model.SubgenreName))
                {
                    subgenre = new Subgenre { Name = model.SubgenreName, Museum = museum };
                }
                else
                {
                    subgenre = museumRepository.GetSubgenre(subgenreId);
                }
            }

            return subgenre;
        }

        private SubjectMatter ResolveToSubjectMatter(PieceViewModel model, Museum museum)
        {
            SubjectMatter subjectMatter = null;
            if (int.TryParse(model.SubjectMatterId, out int subjectMatterId))
            {
                if (subjectMatterId == -1 && !string.IsNullOrWhiteSpace(model.SubjectMatterName))
                {
                    subjectMatter = new SubjectMatter { Name = model.SubjectMatterName, Museum = museum };
                }
                else
                {
                    subjectMatter = museumRepository.GetSubjectMatter(subjectMatterId);
                }
            }

            return subjectMatter;
        }

        private Artist ResolveToArtist(PieceViewModel model, Museum museum)
        {
            Artist artist = null;
            if (int.TryParse(model.ArtistId, out int artistId))
            {
                if (artistId == -1)
                {
                    artist = new Artist
                    {
                        Name = model.ArtistName,
                        AlsoKnownAs = model.ArtistAlsoKnownAs,
                        CityOfOrigin = model.ArtistCity,
                        StateOfOrigin = model.ArtistState,
                        Museum = museum
                    };

                    if (int.TryParse(model.ArtistCountryId, out int countryId))
                    {
                        artist.CountryOfOrigin = museumRepository.GetCountry(countryId);
                    }

                    if (DateTime.TryParse(model.ArtistBirthdate, out DateTime birthdate))
                    {
                        artist.Birthdate = birthdate;
                    }

                    if (DateTime.TryParse(model.ArtistDeathdate, out DateTime deathdate))
                    {
                        artist.Deathdate = deathdate;
                    }
                }
                else
                {
                    artist = museumRepository.GetArtist(artistId);
                }
            }

            return artist;
        }

        private Acquisition ResolveToAcquisition(PieceViewModel model, Museum museum)
        {
            Acquisition acquisition = null;

            if (int.TryParse(model.AcquisitionId, out int acquisitionId))
            {
                if (acquisitionId == -1)
                {
                    acquisition = new Acquisition
                    {
                        Cost = model.Cost,
                        Terms = model.Terms
                    };

                    if (DateTime.TryParse(model.AcquisitionDate, out DateTime acquisitionDate))
                    {
                        acquisition.Date = acquisitionDate;
                    }

                    if (int.TryParse(model.PieceSourceId, out int pieceSourceId))
                    {
                        if (pieceSourceId == -1 && !string.IsNullOrWhiteSpace(model.PieceSourceName))
                        {
                            acquisition.PieceSource = new PieceSource
                            {
                                Name = model.PieceSourceName,
                                Museum = museum
                            };
                        }
                        else
                        {
                            acquisition.PieceSource = museumRepository.GetPieceSource(pieceSourceId);
                        }
                    }

                    if (int.TryParse(model.FundingSourceId, out int fundingSourceId))
                    {
                        if (fundingSourceId == -1 && !string.IsNullOrWhiteSpace(model.FundingSourceName))
                        {
                            acquisition.FundingSource = new FundingSource
                            {
                                Name = model.FundingSourceName,
                                Museum = museum
                            };
                        }
                        else
                        {
                            acquisition.FundingSource = museumRepository.GetFundingSource(fundingSourceId);
                        }
                    }
                }
            }

            return acquisition;
        }
    }
}
