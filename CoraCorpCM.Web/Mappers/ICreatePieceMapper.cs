using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Mappers
{
    public interface ICreatePieceMapper
    {
        CreatePieceModel Map(CreatePieceViewModel model, string userId, int museumId);
    }
}
