using System.Collections.Generic;

namespace CoraCorpCM.App.Acquisitions.Queries.GetAcquisitionList
{
    public interface IGetAcquisitionListQuery
    {
        List<AcquisitionModel> Execute(int museumId);
    }
}
