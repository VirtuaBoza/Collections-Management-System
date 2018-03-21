using System.Linq;
using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Data.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public UserRepository(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public void Add(ApplicationUser entity, string password)
        {
            userManager.CreateAsync(entity, password);
        }

        public ApplicationUser Get(string id)
        {
            return context.Users.Single(u => u.Id == id);
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return context.Users;
        }

        public void Remove(ApplicationUser entity)
        {
            context.Remove(entity);
        }
    }
}
