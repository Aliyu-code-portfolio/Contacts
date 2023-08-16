using Contacts.Domain.Models;
using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Repositories.Abstraction;
using Contacts.Shared.RequestParameter.Common;
using Contacts.Shared.RequestParameter.ModelParameters;
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

        public async Task<PagedList<Contact>> GetAllContacts(ContactRequestInputParameter parameter)
        {
            var result = await _contacts.Where(u => u.FirstName.ToLower()
            .Contains(parameter.SearchTerm.ToLower())
            || u.LastName.ToLower().Contains(parameter.SearchTerm.ToLower())
            ||u.Email.ToLower().Contains(parameter.SearchTerm.ToLower()))
                .Skip((parameter.PageNumber-1)*parameter.PageSize)
                .Take(parameter.PageSize).ToListAsync();
            var count = await _contacts.CountAsync();
            return new PagedList<Contact>(result, count,parameter.PageNumber,parameter.PageSize);
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
