using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition.Repository
{
    public interface IAcquisitionRepositoryFacade
    {
        void AddAcquisition(Acquisition acquisition);
    }
}
