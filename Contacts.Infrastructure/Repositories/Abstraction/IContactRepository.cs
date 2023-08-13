using Contacts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Infrastructure.Repositories.Abstraction
{
    public interface IContactRepository:IRepositoryBase<Contact>
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
        Task<Contact> GetContactByEmail(string email);
        //Search term will use searching
    }
}
