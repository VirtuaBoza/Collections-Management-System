using System.Threading.Tasks;
using CoraCorpCM.Domain;
using CoraCorpCM.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Utilities
{
    public interface IModelMapper
    {
        Piece ResolveToPieceModel(PieceViewModel model, ApplicationUser user);
    }
}