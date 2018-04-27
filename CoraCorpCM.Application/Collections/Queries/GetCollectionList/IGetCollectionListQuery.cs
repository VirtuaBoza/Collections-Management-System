using System.Collections.Generic;

namespace CoraCorpCM.Application.Collections.Queries.GetCollectionList
{
    public interface IGetCollectionListQuery
    {
        List<CollectionModel> Execute(int museumId);
    }
}
