using System.Collections.Generic;

namespace CoraCorpCM.Models
{
    public class Location
    {
        public Location()
        {
            LocationTags = new HashSet<LocationTag>();
        }

        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public ICollection<LocationTag> LocationTags { get; set; }
    }
}
