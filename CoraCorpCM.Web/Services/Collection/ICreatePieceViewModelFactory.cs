using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Services.Collection
{
    public interface ICreatePieceViewModelFactory
    {
        CreatePieceViewModel Create(int museumId);
        CreatePieceViewModel Create(int museumId, CreatePieceViewModel createPieceViewModel);
    }
}
