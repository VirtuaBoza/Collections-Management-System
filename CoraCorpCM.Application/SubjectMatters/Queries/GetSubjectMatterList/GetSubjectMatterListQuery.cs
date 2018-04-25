using CoraCorpCM.Application.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Application.SubjectMatters.Queries.GetSubjectMatterList
{
    public class GetSubjectMatterListQuery : IGetSubjectMatterListQuery
    {
        private readonly ISubjectMatterRepository subjectMatterRepository;

        public GetSubjectMatterListQuery(ISubjectMatterRepository subjectMatterRepository)
        {
            this.subjectMatterRepository = subjectMatterRepository;
        }

        public List<SubjectMatterModel> Execute(int museumId)
        {
            var subjectMatters = subjectMatterRepository.GetAll()
                .Where(s => s.MuseumId == museumId)
                .Select(s => new SubjectMatterModel
                {
                    Id = s.Id,
                    Name = s.Name
                });

            return subjectMatters.ToList();
        }
    }
}
