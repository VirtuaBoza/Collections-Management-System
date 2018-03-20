using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Services
{
    public interface ICreatePieceViewModelFactory
    {
        CreatePieceViewModel Create(string userId);
    }
}
