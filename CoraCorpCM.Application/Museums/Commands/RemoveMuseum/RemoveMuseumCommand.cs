using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Museums.Commands.RemoveMuseum
{
    public class RemoveMuseumCommand : IRemoveMuseumCommand
    {
        private readonly IMuseumRepository museumRepository;

        public RemoveMuseumCommand(IMuseumRepository museumRepository)
        {
            this.museumRepository = museumRepository;
        }

        public void Execute(Museum museum)
        {
            museumRepository.Remove(museum);
        }
    }
}
