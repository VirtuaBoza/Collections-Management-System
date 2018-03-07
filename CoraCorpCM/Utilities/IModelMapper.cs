using CoraCorpCM.Domain;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Utilities
{
    public interface IModelMapper
    {
        Piece ResolveToPieceModel(PieceViewModel model, ApplicationUser user);
    }
}