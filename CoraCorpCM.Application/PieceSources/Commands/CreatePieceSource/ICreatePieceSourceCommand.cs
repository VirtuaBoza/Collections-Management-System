namespace CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource
{
    public interface ICreatePieceSourceCommand
    {
        int Execute(CreatePieceSourceModel model);
    }
}
