using CoraCorpCM.App.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.App.PieceSources.Queries.GetPieceSourceList
{
    public class GetPieceSourceListQuery : IGetPieceSourceListQuery
    {
        private readonly IPieceSourceRepository pieceSourceRepository;

        public GetPieceSourceListQuery(IPieceSourceRepository pieceSourceRepository)
        {
            this.pieceSourceRepository = pieceSourceRepository;
        }

        public List<PieceSourceModel> Execute(int museumId)
        {
            var pieceSources = pieceSourceRepository.GetAll()
                .Where(p => p.MuseumId == museumId)
                .Select(p => new PieceSourceModel
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return pieceSources.ToList();
        }
    }
}
