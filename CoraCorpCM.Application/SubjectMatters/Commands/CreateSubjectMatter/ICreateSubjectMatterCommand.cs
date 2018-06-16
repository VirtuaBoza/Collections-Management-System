namespace CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter
{
    public interface ICreateSubjectMatterCommand
    {
        int Execute(CreateSubjectMatterModel model);
    }
}
