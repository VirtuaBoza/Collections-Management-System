using CoraCorpCM.Domain.Entities;
using System;

namespace CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition.Factory
{
    public interface IAcquisitionFactory
    {
        Acquisition Create(DateTime? date, decimal? cost, string terms, FundingSource fundingSource, PieceSource pieceSource, int museumId);
    }
}
