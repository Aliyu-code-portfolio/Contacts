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
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> context;

        public RepositoryBase(AppDbContext appDbContext)
        {
            context = appDbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
           await context.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await context.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }
}
