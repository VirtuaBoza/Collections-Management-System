using CoraCorpCM.App.Interfaces;
using CoraCorpCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.App.Museums.Queries.GetMuseumId
{
    public class GetMuseumIdQuery : IGetMuseumIdQuery
    {
        private readonly IMuseumRepository museumRepository;

        public GetMuseumIdQuery(IMuseumRepository museumRepository)
        {
            this.museumRepository = museumRepository;
        }

        public MuseumModel Execute(string userId)
        {
            return new MuseumModel();
        }
    }
}
