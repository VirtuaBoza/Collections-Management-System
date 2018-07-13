using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.Collections.Commands.CreateCollection.Factory
{
    public interface ICollectionFactory
    {
        Collection Create(string name, int museumId);
    }
}
