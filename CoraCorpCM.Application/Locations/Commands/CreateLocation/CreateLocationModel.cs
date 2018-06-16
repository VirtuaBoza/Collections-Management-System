namespace CoraCorpCM.Application.Locations.Commands.CreateLocation
{
    public class CreateLocationModel
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int? CountryId { get; set; }
        public int MuseumId { get; set; }
    }
}
