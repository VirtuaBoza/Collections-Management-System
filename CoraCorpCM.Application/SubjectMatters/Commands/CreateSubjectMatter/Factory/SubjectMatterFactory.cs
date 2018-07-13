using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter.Factory
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
