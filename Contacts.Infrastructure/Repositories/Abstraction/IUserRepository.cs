using Contacts.Domain.Models;

namespace Contacts.Infrastructure.Repositories.Abstraction
{
    public interface IUserRepository:IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        //Search term will use searching
    }
}
