using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Media.Commands.CreateMedium.Factory
{
    public interface IMediumFactory
    {
        Medium Create(string name, int museumId);
    }
}
