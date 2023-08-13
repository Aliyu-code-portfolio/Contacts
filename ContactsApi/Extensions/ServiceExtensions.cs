using Contacts.Application.Services.Abstraction;
using Contacts.Application.Services.Implementation;
using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Repositories.UOW.Abstraction;
using Contacts.Infrastructure.Repositories.UOW.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDataBaseContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("Default")));
        public static void ResolveDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
