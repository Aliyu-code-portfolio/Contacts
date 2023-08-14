using Contacts.Domain.Models;
using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Infrastructure.Repositories.Implementation
{
    internal sealed class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        private readonly DbSet<Contact> _contacts;
public ContactRepository(AppDbContext appDbContext):base(appDbContext) 
        {
            _contacts = appDbContext.Set<Contact>();
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByEmail(string email)
        {
            return await _contacts.Where(c => c.Email.Contains(email, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefaultAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _contacts.FindAsync(id);
        }
    }
}
