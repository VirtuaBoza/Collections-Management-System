using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.SubjectMatters
{
    public class SubjectMatterRepository : Repository<SubjectMatter,int>, ISubjectMatterRepository
    {
        public SubjectMatterRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
