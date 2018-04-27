using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.SubjectMatters
{
    public class SubjectMatterRepository : Repository<SubjectMatter,int>, ISubjectMatterRepository
    {
        public SubjectMatterRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
