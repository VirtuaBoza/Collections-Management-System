using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Collections.Commands.CreateCollection.Factory
{
    public interface ICollectionFactory
    {
        Collection Create(string name, int museumId);
    }
}
