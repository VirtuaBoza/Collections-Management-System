using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.SubjectMatters
{
    public class SubjectMatterRepository : Repository<SubjectMatter,int>, ISubjectMatterRepository
    {
        public SubjectMatterRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
