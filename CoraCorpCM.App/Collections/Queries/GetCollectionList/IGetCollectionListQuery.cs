using System.Collections.Generic;

namespace CoraCorpCM.App.Collections.Queries.GetCollectionList
{
    public interface IGetCollectionListQuery
    {
        List<CollectionModel> Execute(int museumId);
    }
}
