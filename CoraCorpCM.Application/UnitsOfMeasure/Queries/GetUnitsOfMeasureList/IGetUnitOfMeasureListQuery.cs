using System.Collections.Generic;

namespace CoraCorpCM.Application.UnitsOfMeasure.Queries.GetUnitsOfMeasureList
{
    public interface IGetUnitOfMeasureListQuery
    {
        List<UnitOfMeasureModel> Execute();
    }
}
