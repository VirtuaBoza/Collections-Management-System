using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Museums.Commands.RemoveMuseum
{
    public interface IRemoveMuseumCommand
    {
        void Execute(Museum museum);
    }
}
