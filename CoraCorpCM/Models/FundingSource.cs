using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.Models
{
    public class FundingSource
    {
        public FundingSource()
        {
            Acquisitions = new HashSet<Acquisition>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Acquisition> Acquisitions { get; set; }
    }
}
