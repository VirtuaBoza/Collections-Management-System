using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.Museums.Commands.RemoveMuseum
{
    public interface IRemoveMuseumCommand
    {
        void Execute(Museum museum);
    }
}
