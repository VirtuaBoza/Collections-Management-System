using System.Collections.Generic;

namespace CoraCorpCM.App.UnitsOfMeasure.Queries.GetUnitsOfMeasureList
{
    public interface IGetUnitOfMeasureListQuery
    {
        List<UnitOfMeasureModel> Execute();
    }
}
