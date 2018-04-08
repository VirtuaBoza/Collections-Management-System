using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Collections.Commands.CreateCollection.Factory
{
    public class CollectionFactory : ICollectionFactory
    {
        public Collection Create(string name, int museumId)
        {
            var collection = new Collection();
            collection.Name = name;
            collection.MuseumId = museumId;

            return collection;
        }
    }
}
