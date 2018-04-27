using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre.Factory
{
    public interface ISubgenreFactory
    {
        Subgenre Create(string name, int museumId);
    }
}
