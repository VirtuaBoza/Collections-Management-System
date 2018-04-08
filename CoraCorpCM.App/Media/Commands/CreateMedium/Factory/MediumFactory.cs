using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Media.Commands.CreateMedium.Factory
{
    public class MediumFactory : IMediumFactory
    {
        public Medium Create(string name, int museumId)
        {
            var medium = new Medium();
            medium.Name = name;
            medium.MuseumId = museumId;

            return medium;
        }
    }
}
