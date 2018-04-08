using System;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Acquisitions.Commands.CreateAcquisition.Factory
{
    public class AcquisitionFactory : IAcquisitionFactory
    {
        public Acquisition Create(DateTime? date, decimal? cost, string terms, FundingSource fundingSource, PieceSource pieceSource, int museumId)
        {
            var acquisition = new Acquisition();
            acquisition.Date = date;
            acquisition.Cost = cost;
            acquisition.Terms = terms;
            acquisition.FundingSource = fundingSource;
            acquisition.PieceSource = pieceSource;
            acquisition.MuseumId = museumId;

            return acquisition;
        }
    }
}
