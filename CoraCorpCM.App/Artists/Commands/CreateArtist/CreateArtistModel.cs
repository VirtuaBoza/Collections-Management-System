using System;

namespace CoraCorpCM.App.Artists.Commands.CreateArtist
{
    public class CreateArtistModel
    {
        public string Name { get; set; }
        public string AlsoKnownAs { get; set; }
        public string StateOfOrigin { get; set; }
        public string CityOfOrigin { get; set; }
        public int? CountryOfOriginId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public int MuseumId { get; set; }
    }
}
