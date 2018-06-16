namespace CoraCorpCM.Application.Locations.Commands.CreateLocation
{
    public interface ICreateLocationCommand
    {
        int Execute(CreateLocationModel model);
    }
}
