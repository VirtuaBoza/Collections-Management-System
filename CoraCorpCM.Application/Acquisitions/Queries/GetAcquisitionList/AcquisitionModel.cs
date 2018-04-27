using System;

namespace CoraCorpCM.Application.Acquisitions.Queries.GetAcquisitionList
{
    public class AcquisitionModel
    {
        public int Id { get; set; }
        public string PieceSource { get; set; }
        public DateTime? Date { get; set; }
    }
}
