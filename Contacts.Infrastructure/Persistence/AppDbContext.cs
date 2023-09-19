using Contacts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Contacts.Infrastructure.Configuration;

namespace Contacts.Infrastructure.Persistence
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
        DbSet<User> Users { get; set; }
        DbSet<Contact> Contacts { get; set; }
    }
}
