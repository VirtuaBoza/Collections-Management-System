using CoraCorpCM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoraCorpCM.Data
{
    public class MuseumRepository : IMuseumRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public MuseumRepository(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        #region Museum
        public Museum CreateMuseum(string name, string shortname, string address1, string address2, string city, string state, string zipCode,
            Country country)
        {
            var museum = new Museum()
            {
                Name = name,
                ShortName = shortname,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                ZipCode = zipCode,
                Country = country,
            };
            context.Museums.Add(museum);
            context.SaveChanges();
            return museum;
        }

        public Museum GetMuseum(ApplicationUser user)
        {
            context.Entry(user).Reference(u => u.Museum).Load();
            return user.Museum;
        }

        public Museum GetMuseum(ClaimsPrincipal principal)
        {
            var user = userManager.GetUserAsync(principal).Result;
            return GetMuseum(user);
        }
        #endregion

        #region Piece
        public async Task<int> CreatePieceForMuseum(Piece piece, Museum museum)
        {
            piece.Museum = museum;
            context.Add(piece);
            return await context.SaveChangesAsync();
        }
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
            return await context.Pieces.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> UpdatePiece(Piece piece)
        {
            context.Update(piece);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeletePiece(int id)
        {
            var piece = await context.Pieces.SingleOrDefaultAsync(m => m.Id == id);
            context.Pieces.Remove(piece);
            return await context.SaveChangesAsync();
        }
        #endregion

        #region Country
        public Country GetCountry(string name)
        {
            return context.Countries.FirstOrDefault(c => c.Name == name);
        }

        public Country GetFirstCountry()
        {
            return context.Countries.FirstOrDefault();
        }
        #endregion

    }
}
