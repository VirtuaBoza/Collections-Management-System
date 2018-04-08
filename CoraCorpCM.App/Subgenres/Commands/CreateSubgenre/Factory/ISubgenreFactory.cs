using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Subgenres.Commands.CreateSubgenre.Factory
{
    public interface ISubgenreFactory
    {
        Subgenre Create(string name, int museumId);
    }
}
