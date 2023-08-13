using Contacts.Domain.Models;
using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Repositories.Implementation
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly DbSet<User> users;

        public UserRepository(AppDbContext appDbContext):base(appDbContext) 
        {
            users = appDbContext.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await users.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await users.Where(u=>u.Email.Contains(email,StringComparison.InvariantCultureIgnoreCase)).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await users.FindAsync(id);
        }
    }
}
