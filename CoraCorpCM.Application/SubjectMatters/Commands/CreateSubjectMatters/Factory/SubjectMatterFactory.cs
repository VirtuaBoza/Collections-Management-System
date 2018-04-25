using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatters.Factory
{
    public class SubjectMatterFactory : ISubjectMatterFactory
    {
        public SubjectMatter Create(string name, int museumId)
        {
            var subjectMatter = new SubjectMatter();
            subjectMatter.Name = name;
            subjectMatter.MuseumId = museumId;

            return subjectMatter;
        }
    }
}
