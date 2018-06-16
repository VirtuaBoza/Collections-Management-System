using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter.Factory
{
    public interface ISubjectMatterFactory
    {
        SubjectMatter Create(string name, int museumId);
    }
}
