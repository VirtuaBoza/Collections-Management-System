using System;

namespace CoraCorpCM.App.Acquisitions.Queries.GetAcquisitionList
{
    public class AcquisitionModel
    {
        public int Id { get; set; }
        public string PieceSource { get; set; }
        public DateTime? Date { get; set; }
    }
}
