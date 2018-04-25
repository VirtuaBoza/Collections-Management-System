using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre.Factory
{
    public class SubgenreFactory : ISubgenreFactory
    {
        public Subgenre Create(string name, int museumId)
        {
            var subgenre = new Subgenre();
            subgenre.Name = name;
            subgenre.MuseumId = museumId;

            return subgenre;
        }
    }
}
