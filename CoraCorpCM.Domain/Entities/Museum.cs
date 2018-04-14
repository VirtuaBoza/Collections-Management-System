using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Entities
{
    public class Museum : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Country Country { get; set; }
        public int RecordCount { get; set; }
    }
}
