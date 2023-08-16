using Contacts.Domain.Models;
using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Repositories.Abstraction;
using Contacts.Shared.RequestParameter.Common;
using Contacts.Shared.RequestParameter.ModelParameters;
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

        public async Task<PagedList<User>> GetAllUsers(UserRequestInputParameter parameter)
        {
            var result = await users.Where(u => u.FirstName.ToLower()
            .Contains(parameter.SearchTerm.ToLower())
            || u.LastName.ToLower().Contains(parameter.SearchTerm.ToLower())
            || u.Email.ToLower().Contains(parameter.SearchTerm.ToLower()))
                .Skip((parameter.PageNumber-1)*parameter.PageSize)
                .Take(parameter.PageSize).ToListAsync();
            var count =await users.CountAsync();
            return new PagedList<User>(result, count, parameter.PageNumber,parameter.PageSize);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await users.Where(u=>u.Email.Contains(email,StringComparison.InvariantCultureIgnoreCase)).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await users.FindAsync(id);
        }
    }
}
