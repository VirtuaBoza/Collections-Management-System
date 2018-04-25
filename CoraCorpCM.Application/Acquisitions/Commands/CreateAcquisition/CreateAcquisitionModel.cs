using System;

namespace CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition
{
    public class CreateAcquisitionModel
    {
        public DateTime? Date { get; set; }
        public int? PieceSourceId { get; set; }
        public decimal? Cost { get; set; }
        public int? FundingSourceId { get; set; }
        public string Terms { get; set; }
        public int MuseumId { get; set; }
    }
}
