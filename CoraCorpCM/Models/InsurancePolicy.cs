using System;

namespace CoraCorpCM.Models
{
    public class InsurancePolicy
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal AmountInsured { get; set; }
        public string Carrier { get; set; }
    }
}
