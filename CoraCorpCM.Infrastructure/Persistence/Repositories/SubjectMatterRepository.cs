using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
{
    public class SubjectMatterRepository : Repository<SubjectMatter,int>, ISubjectMatterRepository
    {
        public SubjectMatterRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
