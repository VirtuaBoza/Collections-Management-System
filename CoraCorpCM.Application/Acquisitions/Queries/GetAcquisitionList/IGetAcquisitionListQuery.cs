using System.Collections.Generic;

namespace CoraCorpCM.Application.Acquisitions.Queries.GetAcquisitionList
{
    public interface IGetAcquisitionListQuery
    {
        List<AcquisitionModel> Execute(int museumId);
    }
}
