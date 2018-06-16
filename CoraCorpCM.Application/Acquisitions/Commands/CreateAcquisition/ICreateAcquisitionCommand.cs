namespace CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition
{
    public interface ICreateAcquisitionCommand
    {
        int Execute(CreateAcquisitionModel model);
    }
}