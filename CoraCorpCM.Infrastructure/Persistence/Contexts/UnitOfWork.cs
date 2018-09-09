using CoraCorpCM.Application.Interfaces.Persistence;

namespace CoraCorpCM.Infrastructure.Persistence.Contexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            context.Save();
        }
    }
}
