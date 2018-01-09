using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CoraCorpCM.Models;

namespace CoraCorpCM.Data
{
    public interface IMuseumRepository
    {
        Museum CreateMuseum(string name, string shortname, 
            string address1, string address2, string city, string state, string zipCode, Country country);
        Museum GetMuseum(ApplicationUser user);
        Museum GetMuseum(ClaimsPrincipal principal);

        Task<int> CreatePieceForMuseum(Piece piece, Museum museum);
        Task<List<Piece>> GetAllPiecesForMuseum(Museum museum);
        bool PieceExists(int id);
        Task<Piece> GetPiece(int? id);
        Task<int> UpdatePiece(Piece piece);
        Task<int> DeletePiece(int id);

        Country GetCountry(string name);
        Country GetFirstCountry();
    }
}