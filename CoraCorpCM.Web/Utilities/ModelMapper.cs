using CoraCorpCM.App.Interfaces;
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

        public Piece ResolveToPieceModel(PieceViewModel pieceViewModel, Museum userMuseum)
        {
            if (pieceViewModel == null) throw new ArgumentNullException();
            if (userMuseum == null) throw new ArgumentNullException();

            var piece = new Piece();

            SetPrimitiveProperties(pieceViewModel, piece, userMuseum);
            SetCreationInformation(pieceViewModel, piece);
            SetContryOfOrigin(pieceViewModel, piece);
            SetArtist(pieceViewModel, piece, userMuseum);
            SetUnitOfMeasurement(pieceViewModel, piece);
            SetMedium(pieceViewModel, piece, userMuseum);
            SetGenre(pieceViewModel, piece, userMuseum);
            SetSubgenre(pieceViewModel, piece, userMuseum);
            SetSubjectMatter(pieceViewModel, piece, userMuseum);
            SetCopyrightYear(pieceViewModel, piece);
            SetAcquisition(pieceViewModel, piece, userMuseum);
            SetInsuranceExpiration(pieceViewModel, piece);
            SetPermanentLocation(pieceViewModel, piece);
            SetCurrentLocation(pieceViewModel, piece);
            SetCollection(pieceViewModel, piece, userMuseum);

            return piece;
        }

        private void SetPrimitiveProperties(PieceViewModel model, Piece piece, Museum userMuseum)
        {
            piece.Title = model.Title;
            piece.Museum = userMuseum;
            piece.AccessionNumber = model.AccessionNumber;
            piece.StateOfOrigin = model.OriginState;
            piece.CityOfOrigin = model.OriginCity;
            piece.Height = model.Height;
            piece.Width = model.Width;
            piece.Depth = model.Depth;
            piece.EstimatedValue = model.EstimatedValue;
            piece.Subject = model.Subject;
            piece.CopyrightOwner = model.CopyrightOwner;
            piece.InsurancePolicyNumber = model.PolicyNumber;
            piece.InsuranceAmount = model.AmountInsured;
            piece.InsuranceCarrier = model.Carrier;
            piece.IsFramed = model.IsFramed;
        }

        private static void SetCreationInformation(PieceViewModel model, Piece piece)
        {
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
        }

        private void SetContryOfOrigin(PieceViewModel model, Piece piece)
        {
            if (int.TryParse(model.OriginCountryId, out int originCountryId))
            {
                piece.CountryOfOrigin = museumRepository.GetEntity<Country>(originCountryId);
            }
        }

        private void SetArtist(PieceViewModel model, Piece piece, Museum museum)
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
                        artist.CountryOfOrigin = museumRepository.GetEntity<Country>(countryId);
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
                    artist = museumRepository.GetEntity<Artist>(artistId);
                }
            }

            piece.Artist = artist;
        }

        private void SetUnitOfMeasurement(PieceViewModel model, Piece piece)
        {
            if (int.TryParse(model.UnitOfMeasureId, out int unitOfMeasureId))
            {
                piece.UnitOfMeasure = museumRepository.GetEntity<UnitOfMeasure>(unitOfMeasureId);
            }
        }

        private void SetMedium(PieceViewModel model, Piece piece, Museum museum)
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
                    medium = museumRepository.GetEntity<Medium>(mediumId);
                }
            }

            piece.Medium = medium;
        }

        private void SetGenre(PieceViewModel model, Piece piece, Museum museum)
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
                    genre = museumRepository.GetEntity<Genre>(genreId);
                }
            }

            piece.Genre = genre;
        }

        private void SetSubgenre(PieceViewModel model, Piece piece, Museum museum)
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
                    subgenre = museumRepository.GetEntity<Subgenre>(subgenreId);
                }
            }

            piece.Subgenre = subgenre;
        }

        private void SetSubjectMatter(PieceViewModel model, Piece piece, Museum museum)
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
                    subjectMatter = museumRepository.GetEntity<SubjectMatter>(subjectMatterId);
                }
            }

            piece.SubjectMatter = subjectMatter;
        }

        private static void SetCopyrightYear(PieceViewModel pieceViewModel, Piece piece)
        {
            if (int.TryParse(pieceViewModel.CopyrightYear, out int copyrightYear))
            {
                piece.CopyrightYear = copyrightYear;
            }
        }

        private void SetAcquisition(PieceViewModel model, Piece piece, Museum museum)
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
                            acquisition.PieceSource = museumRepository.GetEntity<PieceSource>(pieceSourceId);
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
                            acquisition.FundingSource = museumRepository.GetEntity<FundingSource>(fundingSourceId);
                        }
                    }
                }
                else
                {
                    acquisition = museumRepository.GetEntity<Acquisition>(acquisitionId);
                }
            }

            piece.Acquisition = acquisition;
        }

        private void SetPermanentLocation(PieceViewModel pieceViewModel, Piece piece)
        {
            Location permanentLocation = null;
            if (int.TryParse(pieceViewModel.PermanentLocationId, out int permLocId))
            {
                if (permLocId == -1 && !string.IsNullOrWhiteSpace(pieceViewModel.PermanentLocationName))
                {
                    permanentLocation = new Location
                    {
                        Name = pieceViewModel.PermanentLocationName,
                        Address1 = pieceViewModel.PermanentAddress1,
                        Address2 = pieceViewModel.PermanentAddress2,
                        City = pieceViewModel.PermanentCity,
                        State = pieceViewModel.PermanentState,
                        ZipCode = pieceViewModel.PermanentZipCode
                    };
                    if (int.TryParse(pieceViewModel.PermanentCountryId, out int permCountry))
                    {
                        permanentLocation.Country = museumRepository.GetEntity<Country>(permCountry);
                    }
                }
                else
                {
                    permanentLocation = museumRepository.GetEntity<Location>(permLocId);
                }
            }

            piece.PermanentLocation = permanentLocation;
        }

        private static void SetInsuranceExpiration(PieceViewModel pieceViewModel, Piece piece)
        {
            if (DateTime.TryParse(pieceViewModel.ExpirationDate, out DateTime expDate))
            {
                piece.InsuranceExpirationDate = expDate;
            }
        }

        private void SetCurrentLocation(PieceViewModel pieceViewModel, Piece piece)
        {
            Location currentLocation = null;
            if (int.TryParse(pieceViewModel.CurrentLocationId, out int currLocId))
            {
                if (currLocId == -1 && !string.IsNullOrWhiteSpace(pieceViewModel.CurrentLocationName))
                {
                    currentLocation = new Location
                    {
                        Name = pieceViewModel.CurrentLocationName,
                        Address1 = pieceViewModel.CurrentAddress1,
                        Address2 = pieceViewModel.CurrentAddress2,
                        City = pieceViewModel.CurrentCity,
                        State = pieceViewModel.CurrentState,
                        ZipCode = pieceViewModel.CurrentZipCode
                    };
                    if (int.TryParse(pieceViewModel.CurrentCountryId, out int currCountry))
                    {
                        currentLocation.Country = museumRepository.GetEntity<Country>(currCountry);
                    }
                }
                else
                {
                    currentLocation = museumRepository.GetEntity<Location>(currLocId);
                }
            }

            piece.CurrentLocation = currentLocation;
        }

        private void SetCollection(PieceViewModel model, Piece piece, Museum museum)
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
                    collection = museumRepository.GetEntity<Collection>(collId);
                }
            }

            piece.Collection = collection;
        }
    }
}
