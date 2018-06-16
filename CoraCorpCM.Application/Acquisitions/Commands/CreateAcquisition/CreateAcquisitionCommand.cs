using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition.Repository;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition
{
    public class CreateAcquisitionCommand : ICreateAcquisitionCommand
    {
        private readonly IAcquisitionRepositoryFacade repository;

        public CreateAcquisitionCommand(IAcquisitionRepositoryFacade repository)
        {
            this.repository = repository;
        }

        public int Execute(CreateAcquisitionModel model)
        {
            repository.AddAcquisition(new Acquisition());
            return default(int);
        }
    }
}
