using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Application.Models
{
    public class FundingSource : IEntity<int>
    {
        public FundingSource()
        {
            Acquisitions = new HashSet<Acquisition>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Acquisition> Acquisitions { get; set; }
    }
}
