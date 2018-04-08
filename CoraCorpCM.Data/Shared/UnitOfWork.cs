using CoraCorpCM.App.Interfaces.Persistence;

namespace CoraCorpCM.Data.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.Save();
        }
    }
}
