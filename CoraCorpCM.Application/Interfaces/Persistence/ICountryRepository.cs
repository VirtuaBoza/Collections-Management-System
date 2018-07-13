﻿using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.Interfaces.Persistence
{
    public interface ICountryRepository : IReadOnlyRepository<Country,int>
    {
    }
}
