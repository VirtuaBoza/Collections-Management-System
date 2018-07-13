using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter.Factory
{
    public interface ISubjectMatterFactory
    {
        SubjectMatter Create(string name, int museumId);
    }
}
