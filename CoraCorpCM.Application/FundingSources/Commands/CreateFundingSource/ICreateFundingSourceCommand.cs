namespace CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource
{
    public interface ICreateFundingSourceCommand
    {
        int Execute(CreateFundingSourceModel model);
    }
}
