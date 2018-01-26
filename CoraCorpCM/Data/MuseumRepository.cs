using CoraCorpCM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<SelectListItem> GetAcquisitionSelections(Museum museum)
        {
            return context.Acquisitions
                .Where(a => a.Museum == museum)
                .Select(a => new SelectListItem
                {
                    Text = a.PieceSource.Name + " " + a.Date,
                    Value = a.Id.ToString()
                });
        }
        #endregion

        #region Artist
        public async Task<Artist> GetArtist(int id)
        {
            return await context.Artists.SingleOrDefaultAsync<Artist>(p => p.Id == id);
        }

        public IEnumerable<SelectListItem> GetArtistSelections(Museum museum)
        {
            return context.Artists
                .Where(a => a.Museum == museum)
                .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
        }
        #endregion

        #region Country
        public Country GetCountry(int id)
        {
            return context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public Country GetFirstCountry()
        {
            return context.Countries.FirstOrDefault();
        }

        public IEnumerable<SelectListItem> GetCountrySelections()
        {
            return context.Countries.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }
        #endregion

        #region Funding Source
        public IEnumerable<SelectListItem> GetFundingSourceSelections(Museum museum)
        {
            return context.FundingSources
                .Where(f => f.Museum == museum)
                .Select(f => new SelectListItem { Text = f.Name, Value = f.Id.ToString() });
        }
        #endregion

        #region Genre
        public IEnumerable<SelectListItem> GetGenreSelections(Museum museum)
        {
            return context.Genres
                .Where(g => g.Museum == museum)
                .Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() });
        }
        #endregion

        #region Location
        // Create
        public Location CreateLocation(string name, string address1, string address2, string city, string state, string zipCode, Country country, Museum museum)
        {
            var location = new Location
            {
                Name = name,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                ZipCode = zipCode,
                Country = country,
                Museum = museum
            };
            context.Locations.Add(location);
            context.SaveChanges();
            return location;
        }

        // Read
        public IEnumerable<SelectListItem> GetLocationSelections(Museum museum)
        {
            return context.Locations
                .Where(l => l.Museum == museum)
                .Select(l => new SelectListItem { Text = l.Name, Value = l.Id.ToString() });
        }
        #endregion

        #region Medium
        public Medium CreateMedium(string name, Museum museum)
        {
            var medium = new Medium
            {
                Name = name,
                Museum = museum
            };
            context.Media.Add(medium);
            context.SaveChanges();
            return medium;
        }

        public IEnumerable<SelectListItem> GetMediumSelections(Museum museum)
        {
            return context.Media
                .Where(m => m.Museum == museum)
                .Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
        }
        #endregion

        #region Museum
        // Create
        public Museum CreateMuseum(string name, string shortname, 
            string address1, string address2, string city, string state, string zipCode, Country country,
            ApplicationUser creator)
        {
            var museum = new Museum
            {
                Name = name,
                ShortName = shortname,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                ZipCode = zipCode,
                Country = country,
                RecordCount = 0,
                Users = new List<ApplicationUser>
                {
                    creator
                }
            };
            
            context.Museums.Add(museum);
            context.SaveChanges();
            return museum;
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
        public async Task<int> CreatePiece(
            string accessionNumber,
            Artist artist,
            string title,
            int creationDay,
            int creationMonth,
            int creationYear,
            Country countryOfOrigin,
            string stateOfOrigin,
            string cityOfOrigin,
            double height,
            double width,
            double depth,
            UnitOfMeasure unitOfMeasure,
            decimal estimatedValue,
            Medium medium,
            Genre genre,
            Subgenre subgenre,
            string subject,
            SubjectMatter subjectMatter,
            int copyrightYear,
            string copyrightOwner,
            Acquisition acquisition,
            string policyNumber,
            DateTime expiration,
            decimal amountInsured,
            string carrier,
            bool isFramed,
            Location currentLocation,
            Location permanentLocation,
            Collection collection,
            ApplicationUser user, Museum museum)
        {
            var piece = new Piece
            {
                AccessionNumber = accessionNumber,
                Artist = artist,
                Title = title,
                CreationDay = creationDay,
                CreationMonth = creationMonth,
                CreationYear = creationYear,
                CountryOfOrigin = countryOfOrigin,
                StateOfOrigin = stateOfOrigin,
                CityOfOrigin = cityOfOrigin,
                Height = height,
                Width = width,
                Depth = depth,
                UnitOfMeasure = unitOfMeasure,
                EstimatedValue = estimatedValue,
                Medium = medium,
                Genre = genre,
                Subgenre = subgenre,
                Subject = subject,
                SubjectMatter = subjectMatter,
                CopyrightYear = copyrightYear,
                CopyrightOwner = copyrightOwner,
                Acquisition = acquisition,
                InsurancePolicyNumber = policyNumber,
                InsuranceExpirationDate = expiration,
                InsuranceAmount = amountInsured,
                InsuranceCarrier = carrier,
                IsFramed = isFramed,
                CurrentLocation = currentLocation,
                PermanentLocation = permanentLocation,
                Collection = collection,
                LastModifiedBy = user,
                Museum = museum,
                RecordNumber = ++museum.RecordCount
            };
            context.Add(piece);
            return await context.SaveChangesAsync();
        }

        public async Task<int> CreatePiece(Piece piece)
        {
            piece.RecordNumber = ++piece.Museum.RecordCount;
            context.Add(piece);
            return await context.SaveChangesAsync();
        }

        // Read
        public async Task<List<Piece>> GetAllPiecesForMuseum(Museum museum)
        {
            return await context.Pieces.Where(p => p.Museum == museum).ToListAsync();
        }

        public bool PieceExists(int id)
        {
            return context.Pieces.Any(e => e.Id == id);
        }

        public async Task<Piece> GetPiece(int? id)
        {
            return await context.Pieces.SingleOrDefaultAsync(p => p.Id == id);
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
        public IEnumerable<SelectListItem> GetPieceSourceSelections(Museum museum)
        {
            return context.PieceSources
                .Where(s => s.Museum == museum)
                .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
        }
        #endregion

        #region Subgenre
        public IEnumerable<SelectListItem> GetSubgenreSelections(Museum museum)
        {
            return context.Subgenres
                .Where(s => s.Museum == museum)
                .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
        }
        #endregion

        #region Subject Matter
        public IEnumerable<SelectListItem> GetSubjectMatterSelections(Museum museum)
        {
            return context.SubjectMatters
                .Where(s => s.Museum == museum)
                .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
        }
        #endregion

        #region Unit of Measure
        public IEnumerable<SelectListItem> GetUnitOfMeasureSelections()
        {
            return context.UnitsOfMeasure.Select(c => new SelectListItem { Text = c.Abbreviation, Value = c.Id.ToString() });
        }
        #endregion
    }
}
