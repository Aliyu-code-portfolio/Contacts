using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Repositories.Abstraction;
using Contacts.Infrastructure.Repositories.Implementation;
using Contacts.Infrastructure.Repositories.UOW.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Infrastructure.Repositories.UOW.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private IUserRepository _userRepository;
        private IContactRepository _contactRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IUserRepository UserRepository => _userRepository?? new UserRepository(_appDbContext);

        public IContactRepository ContactRepository => _contactRepository?? new ContactRepository(_appDbContext);

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
