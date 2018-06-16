namespace CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre
{
    public interface ICreateSubgenreCommand
    {
        int Execute(CreateSubgenreModel model);
    }
}
