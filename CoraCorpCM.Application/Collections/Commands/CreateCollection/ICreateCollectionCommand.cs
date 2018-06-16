namespace CoraCorpCM.Application.Collections.Commands.CreateCollection
{
    public interface ICreateCollectionCommand
    {
        int Execute(CreateCollectionModel model);
    }
}
