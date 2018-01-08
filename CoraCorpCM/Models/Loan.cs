using System;

namespace CoraCorpCM.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        public Location FromLocation { get; set; }
        public Location ToLocation { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Exhibition Exhibition { get; set; }
        public Upload LoanAgreement { get; set; }
        public string Terms { get; set; }
    }
}
