using System.Collections.Generic;

namespace CoraCorpCM.Models
{
    public class Museum
    {
        public Museum()
        {
            Acquisitions = new HashSet<Acquisition>();
            ApplicationUsers = new HashSet<ApplicationUser>();
            Artists = new HashSet<Artist>();
            Collections = new HashSet<Collection>();
            Conditions = new HashSet<Condition>();
            Exhibitions = new HashSet<Exhibition>();
            Genres = new HashSet<Genre>();
            Inspections = new HashSet<Inspection>();
            Inspectors = new HashSet<Inspector>();
            InsurancePolicies = new HashSet<InsurancePolicy>();
            Loans = new HashSet<Loan>();
            Locations = new HashSet<Location>();
            Media = new HashSet<Medium>();
            Pieces = new HashSet<Piece>();
            Subgenres = new HashSet<Subgenre>();
            SubjectMatters = new HashSet<SubjectMatter>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Country Country { get; set; }
        public Upload Logo { get; set; }
        public ICollection<Acquisition> Acquisitions { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Collection> Collections { get; set; }
        public ICollection<Condition> Conditions { get; set; }
        public ICollection<Exhibition> Exhibitions { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Inspection> Inspections { get; set; }
        public ICollection<Inspector> Inspectors { get; set; }
        public ICollection<InsurancePolicy> InsurancePolicies { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Medium> Media { get; set; }
        public ICollection<Piece> Pieces { get; set; }
        public ICollection<Subgenre> Subgenres { get; set; }
        public ICollection<SubjectMatter> SubjectMatters { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
