using CoraCorpCM.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Application.Acquisitions.Queries.GetAcquisitionList
{
    public class GetAcquisitionListQuery : IGetAcquisitionListQuery
    {
        private readonly IAcquisitionRepository acquisitionRepository;

        public GetAcquisitionListQuery(IAcquisitionRepository acquisitionRepository)
        {
            this.acquisitionRepository = acquisitionRepository;
        }

        public List<AcquisitionModel> Execute(int museumId)
        {
            var acquisitions = acquisitionRepository.GetAll()
                .Where(a => a.MuseumId == museumId)
                .Select(a => new AcquisitionModel
                {
                    Id = a.Id,
                    PieceSource = a.PieceSource.Name,
                    Date = a.Date
                });

            return acquisitions.ToList();
        }
    }
}
