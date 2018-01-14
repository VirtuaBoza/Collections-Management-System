using System.Collections.Generic;

namespace CoraCorpCM.Models
{
    public class FundingSource
    {
        public FundingSource()
        {
            Acquisitions = new HashSet<Acquisition>();
        }
        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string Name { get; set; }
        public ICollection<Acquisition> Acquisitions { get; set; }
    }
}
