using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Museums.Commands.RemoveMuseum
{
    public interface IRemoveMuseumCommand
    {
        void Execute(Museum museum);
    }
}
