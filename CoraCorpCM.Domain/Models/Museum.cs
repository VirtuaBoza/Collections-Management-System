using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class Museum : INamedEntity
    {
        public Museum()
        {
            Acquisitions = new HashSet<Acquisition>();
            Users = new HashSet<ApplicationUser>();
            Artists = new HashSet<Artist>();
            Collections = new HashSet<Collection>();
            Conditions = new HashSet<Condition>();
            Exhibitions = new HashSet<Exhibition>();
            FundingSources = new HashSet<FundingSource>();
            Genres = new HashSet<Genre>();
            Inspections = new HashSet<Inspection>();
            Inspectors = new HashSet<Inspector>();
            Loans = new HashSet<Loan>();
            Locations = new HashSet<Location>();
            Media = new HashSet<Medium>();
            Pieces = new HashSet<Piece>();
            Subgenres = new HashSet<Subgenre>();
            SubjectMatters = new HashSet<SubjectMatter>();
            Tags = new HashSet<Tag>();
            Uploads = new HashSet<Upload>();
        }

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
        public virtual Country Country { get; set; }
        public virtual Upload Logo { get; set; }
        public int RecordCount { get; set; }

        public virtual ICollection<Acquisition> Acquisitions { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Condition> Conditions { get; set; }
        public virtual ICollection<Exhibition> Exhibitions { get; set; }
        public virtual ICollection<FundingSource> FundingSources { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }
        public virtual ICollection<Inspector> Inspectors { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Piece> Pieces { get; set; }
        public virtual ICollection<Subgenre> Subgenres { get; set; }
        public virtual ICollection<SubjectMatter> SubjectMatters { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Upload> Uploads { get; set; }
    }
}
