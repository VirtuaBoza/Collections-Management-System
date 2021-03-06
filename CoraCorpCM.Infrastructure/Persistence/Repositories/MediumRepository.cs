﻿using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
{
    public class MediumRepository : Repository<Medium,int>, IMediumRepository
    {
        public MediumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
