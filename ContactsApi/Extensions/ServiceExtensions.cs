using Contacts.Application.Services.Abstraction;
using Contacts.Application.Services.Implementation;
using Contacts.Domain.Models;
using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Repositories.UOW.Abstraction;
using Contacts.Infrastructure.Repositories.UOW.Implementation;
using Microsoft.AspNetCore.Identity;
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
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
