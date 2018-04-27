using CoraCorpCM.Domain.Entities;
using System;

namespace CoraCorpCM.Application.Artists.Commands.CreateArtist.Factory
{
    public interface IArtistFactory
    {
        Artist Create(string name, string alsoKnownAs, string cityOfOrigin, string stateOfOrigin, Country countryOfOrigin, DateTime? birthdate, DateTime? deathdate, int museumId);
    }
}
