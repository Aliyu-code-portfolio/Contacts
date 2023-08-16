using Azure;
using Contacts.Domain.Models;
using Contacts.Shared.RequestParameter.Common;
using Contacts.Shared.RequestParameter.ModelParameters;

namespace Contacts.Infrastructure.Repositories.Abstraction
{
    public interface IUserRepository:IRepositoryBase<User>
    {
        Task<PagedList<User>> GetAllUsers(UserRequestInputParameter parameter);
        Task<User> GetUserById(string id);
        Task<User> GetUserByEmail(string email);
        //Search term will use searching
    }
}
