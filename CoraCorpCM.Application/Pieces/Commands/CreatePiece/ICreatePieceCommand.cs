namespace CoraCorpCM.Application.Pieces.Commands.CreatePiece
{
    public interface ICreatePieceCommand
    {
        int Execute(CreatePieceModel model);
    }
}
