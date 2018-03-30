using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Museums.Queries
{
    public class MuseumModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public int RecordCount { get; set; }
    }
}
