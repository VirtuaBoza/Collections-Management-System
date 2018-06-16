namespace CoraCorpCM.Application.Media.Commands.CreateMedium
{
    public interface ICreateMediumCommand
    {
        int Execute(CreateMediumModel model);
    }
}
