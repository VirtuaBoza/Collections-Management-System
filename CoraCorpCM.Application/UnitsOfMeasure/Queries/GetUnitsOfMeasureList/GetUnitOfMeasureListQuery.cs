using CoraCorpCM.Application.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Application.UnitsOfMeasure.Queries.GetUnitsOfMeasureList
{
    public class GetUnitOfMeasureListQuery : IGetUnitOfMeasureListQuery
    {
        private readonly IUnitOfMeasureRepository unitOfMeasureRepository;

        public GetUnitOfMeasureListQuery(IUnitOfMeasureRepository unitOfMeasureRepository)
        {
            this.unitOfMeasureRepository = unitOfMeasureRepository;
        }

        public List<UnitOfMeasureModel> Execute()
        {
            var unitsOfMeasure = unitOfMeasureRepository.GetAll()
                .Select(u => new UnitOfMeasureModel
                {
                    Id = u.Id,
                    Abbreviation = u.Abbreviation
                });

            return unitsOfMeasure.ToList();
        }
    }
}
