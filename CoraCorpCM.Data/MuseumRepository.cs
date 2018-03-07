using CoraCorpCM.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoraCorpCM.Data
{
    public class MuseumRepository : IMuseumRepository
    {
        private readonly ApplicationDbContext context;

        public MuseumRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        #region Acquisition
        public IEnumerable<Acquisition> GetAcquisitions(Museum museum)
        {
            return context.Acquisitions
                .Where(a => a.Museum == museum).ToList();
        }
        #endregion

        #region Artist
        public Artist GetArtist(int id)
        {
            return context.Artists.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Artist> GetArtists(Museum museum)
        {
            return context.Artists
                .Where(a => a.Museum == museum);
        }
        #endregion

        #region Collection
        public int AddCollection(Collection collection)
        {
            context.Add(collection);
            return context.SaveChanges();
        }

        public Collection GetCollection(int id)
        {
            return context.Collections.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Collection> GetCollections(Museum museum)
        {
            return context.Collections
                .Where(c => c.Museum == museum);
        }
        #endregion

        #region Country
        public Country GetCountry(int id)
        {
            return context.Countries.SingleOrDefault(c => c.Id == id);
        }

        public Country GetFirstCountry()
        {
            return context.Countries.FirstOrDefault();
        }

        public IEnumerable<Country> GetCountries()
        {
            return context.Countries.AsNoTracking();
        }
        #endregion

        #region Funding Source
        public FundingSource GetFundingSource(int id)
        {
            return context.FundingSources.SingleOrDefault(f => f.Id == id);
        }

        public IEnumerable<FundingSource> GetFundingSources(Museum museum)
        {
            return context.FundingSources
                .Where(f => f.Museum == museum)
                .AsNoTracking();
        }
        #endregion

        #region Genre
        public int AddGenre(Genre genre)
        {
            context.Genres.Add(genre);
            return context.SaveChanges();
        }

        public Genre GetGenre(int id)
        {
            return context.Genres.SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Genre> GetGenres(Museum museum)
        {
            return context.Genres.Where(g => g.Museum == museum).AsNoTracking();
        }
        #endregion

        #region Location
        // Create
        public int AddLocation(Location location)
        {
            context.Locations.Add(location);
            return context.SaveChanges();
        }

        public Location GetLocation(int id)
        {
            return context.Locations.SingleOrDefault(l => l.Id == id);
        }

        public IEnumerable<Location> GetLocations(Museum museum)
        {
            return context.Locations.Where(l => l.Museum == museum).AsNoTracking();
        }
        #endregion

        #region Medium
        public int AddMedium(Medium medium)
        {
            context.Media.Add(medium);
            return context.SaveChanges();
        }

        public Medium GetMedium(int id)
        {
            return context.Media.SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Medium> GetMedia(Museum museum)
        {
            return context.Media.Where(m => m.Museum == museum).AsNoTracking();
        }
        #endregion

        #region Museum
        // Create
        public int AddMuseum(Museum museum)
        {
            context.Museums.Add(museum);
            return context.SaveChanges();
        }

        // Read
        public Museum GetMuseum(ApplicationUser user)
        {
            context.Entry(user).Reference(u => u.Museum).Load();
            return user.Museum;
        }
        #endregion

        #region Piece
        // Create
        public int AddPiece(Piece piece)
        {
            piece.RecordNumber = ++piece.Museum.RecordCount;
            piece.IsArchived = false;
            piece.LastModified = DateTime.Now;
            context.Add(piece);
            return context.SaveChanges();
        }

        // Read
        public IEnumerable<Piece> GetPieces(Museum museum)
        {
            return context.Pieces.Where(p => p.Museum == museum).ToList();
        }

        public bool PieceExists(int id)
        {
            return context.Pieces.Any(e => e.Id == id);
        }

        public Piece GetPiece(int? id)
        {
            return context.Pieces.SingleOrDefault(p => p.Id == id);
        }

        // Update
        public async Task<int> UpdatePiece(Piece piece)
        {
            context.Update(piece);
            return await context.SaveChangesAsync();
        }

        // Delete
        public async Task<int> DeletePiece(int id)
        {
            var piece = await context.Pieces.SingleOrDefaultAsync(p => p.Id == id);
            context.Pieces.Remove(piece);
            return await context.SaveChangesAsync();
        }
        #endregion

        #region Piece Source
        public PieceSource GetPieceSource(int id)
        {
            return context.PieceSources.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<PieceSource> GetPieceSources(Museum museum)
        {
            return context.PieceSources.Where(s => s.Museum == museum).AsNoTracking();
        }
        #endregion

        #region Subgenre
        public int AddSubgenre(Subgenre subgenre)
        {
            context.Add(subgenre);
            return context.SaveChanges();
        }

        public Subgenre GetSubgenre(int id)
        {
            return context.Subgenres.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Subgenre> GetSubgenres(Museum museum)
        {
            return context.Subgenres.Where(g => g.Museum == museum).AsNoTracking();
        }
        #endregion

        #region Subject Matter
        public int AddSubjectMatter(SubjectMatter subjectMatter)
        {
            context.Add(subjectMatter);
            return context.SaveChanges();
        }

        public SubjectMatter GetSubjectMatter(int id)
        {
            return context.SubjectMatters.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<SubjectMatter> GetSubjectMatters(Museum museum)
        {
            return context.SubjectMatters.Where(s => s.Museum == museum).AsNoTracking();
        }
        #endregion

        #region Unit of Measure
        public UnitOfMeasure GetUnitOfMeasure(int id)
        {
            return context.UnitsOfMeasure.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<UnitOfMeasure> GetUnitsOfMeasure()
        {
            return context.UnitsOfMeasure.AsNoTracking();
        }
        #endregion
    }
}
