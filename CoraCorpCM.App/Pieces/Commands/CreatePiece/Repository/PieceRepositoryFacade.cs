using System;
using System.Linq;
using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Pieces.Commands.CreatePiece.Repository
{
    public class PieceRepositoryFacade : IPieceRepositoryFacade
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfMeasureRepository unitOfMeasureRepository;
        private readonly IArtistRepository artistRepository;
        private readonly IMediumRepository mediumRepository;
        private readonly IGenreRepository genreRepository;
        private readonly ISubgenreRepository subgenreRepository;
        private readonly ISubjectMatterRepository subjectMatterRepository;
        private readonly IAcquisitionRepository acquisitionRepository;
        private readonly IFundingSourceRepository fundingSourceRepository;
        private readonly IPieceSourceRepository pieceSourceRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ICollectionRepository collectionRepository;
        private readonly IPieceRepository pieceRepository;
        private readonly IMuseumRepository museumRepository;

        public PieceRepositoryFacade(
            ICountryRepository countryRepository,
            IUnitOfMeasureRepository unitOfMeasureRepository,
            IArtistRepository artistRepository,
            IMediumRepository mediumRepository,
            IGenreRepository genreRepository,
            ISubgenreRepository subgenreRepository,
            ISubjectMatterRepository subjectMatterRepository,
            IAcquisitionRepository acquisitionRepository,
            IFundingSourceRepository fundingSourceRepository,
            IPieceSourceRepository pieceSourceRepository,
            ILocationRepository locationRepository,
            ICollectionRepository collectionRepository,
            IPieceRepository pieceRepository,
            IMuseumRepository museumRepository)
        {
            this.countryRepository = countryRepository;
            this.unitOfMeasureRepository = unitOfMeasureRepository;
            this.artistRepository = artistRepository;
            this.mediumRepository = mediumRepository;
            this.genreRepository = genreRepository;
            this.subgenreRepository = subgenreRepository;
            this.subjectMatterRepository = subjectMatterRepository;
            this.acquisitionRepository = acquisitionRepository;
            this.fundingSourceRepository = fundingSourceRepository;
            this.pieceSourceRepository = pieceSourceRepository;
            this.locationRepository = locationRepository;
            this.collectionRepository = collectionRepository;
            this.pieceRepository = pieceRepository;
            this.museumRepository = museumRepository;
        }

        public void AddArtist(Artist artist)
        {
            artistRepository.Add(artist);
        }

        public Artist GetArtist(int id)
        {
            return artistRepository.Get(id);
        }

        public Country GetCountry(int id)
        {
            return countryRepository.Get(id);
        }

        public Medium GetMedium(int id)
        {
            return mediumRepository.Get(id);
        }

        public IQueryable<Medium> GetMedia()
        {
            return mediumRepository.GetAll();
        }

        public UnitOfMeasure GetUnitOfMeasure(int id)
        {
            return unitOfMeasureRepository.Get(id);
        }

        public void AddMedium(Medium medium)
        {
            mediumRepository.Add(medium);
        }

        public Genre GetGenre(int id)
        {
            return genreRepository.Get(id);
        }

        public IQueryable<Genre> GetGenres()
        {
            return genreRepository.GetAll();
        }

        public void AddGenre(Genre genre)
        {
            genreRepository.Add(genre);
        }

        public Subgenre GetSubgenre(int id)
        {
            return subgenreRepository.Get(id);
        }

        public IQueryable<Subgenre> GetSubgenres()
        {
            return subgenreRepository.GetAll();
        }

        public void AddSubgenre(Subgenre subgenre)
        {
            subgenreRepository.Add(subgenre);
        }

        public SubjectMatter GetSubjectMatter(int id)
        {
            return subjectMatterRepository.Get(id);
        }

        public IQueryable<SubjectMatter> GetSubjectMatters()
        {
            return subjectMatterRepository.GetAll();
        }

        public void AddSubjectMatter(SubjectMatter subjectMatter)
        {
            subjectMatterRepository.Add(subjectMatter);
        }

        public Acquisition GetAcquisition(int id)
        {
            return acquisitionRepository.Get(id);
        }

        public void AddAcquisition(Acquisition acquisition)
        {
            acquisitionRepository.Add(acquisition);
        }

        public IQueryable<FundingSource> GetFundingSources()
        {
            return fundingSourceRepository.GetAll();
        }

        public void AddFundingSource(FundingSource fundingSource)
        {
            fundingSourceRepository.Add(fundingSource);
        }

        public FundingSource GetFundingSource(int id)
        {
            return fundingSourceRepository.Get(id);
        }

        public PieceSource GetPieceSource(int id)
        {
            return pieceSourceRepository.Get(id);
        }

        public IQueryable<PieceSource> GetPieceSources()
        {
            return pieceSourceRepository.GetAll();
        }

        public void AddPieceSource(PieceSource pieceSource)
        {
            pieceSourceRepository.Add(pieceSource);
        }

        public Location GetLocation(int id)
        {
            return locationRepository.Get(id);
        }

        public void AddLocation(Location location)
        {
            locationRepository.Add(location);
        }

        public Collection GetCollection(int id)
        {
            return collectionRepository.Get(id);
        }

        public IQueryable<Collection> GetCollections()
        {
            return collectionRepository.GetAll();
        }

        public void AddCollection(Collection collection)
        {
            collectionRepository.Add(collection);
        }

        public void AddPiece(Piece piece)
        {
            pieceRepository.Add(piece);
        }

        public Museum GetMuseum(int id)
        {
            return museumRepository.Get(id);
        }
    }
}
