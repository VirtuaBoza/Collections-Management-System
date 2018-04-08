using System;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Artists.Commands.CreateArtist.Factory
{
    public class ArtistFactory : IArtistFactory
    {
        public Artist Create(string name, string alsoKnownAs, string cityOfOrigin, string stateOfOrigin, Country countryOfOrigin, DateTime? birthdate, DateTime? deathdate, int museumId)
        {
            var artist = new Artist();
            artist.Name = name;
            artist.AlsoKnownAs = alsoKnownAs;
            artist.CityOfOrigin = cityOfOrigin;
            artist.StateOfOrigin = stateOfOrigin;
            artist.CountryOfOrigin = countryOfOrigin;
            artist.Birthdate = birthdate;
            artist.Deathdate = deathdate;
            artist.MuseumId = museumId;
            return artist;
        }
    }
}
