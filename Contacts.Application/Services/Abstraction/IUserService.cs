using Contacts.Domain.Dtos.Request;
using Contacts.Domain.Dtos.Response;

namespace Contacts.Application.Services.Abstraction
{
    public interface IUserService
    {
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsers();
        Task<StandardResponse<UserResponseDto>> GetUserById(int id);
        Task<StandardResponse<UserResponseDto>> GetUserByEmail(string email);
        Task<StandardResponse<UserResponseDto>> UpdateUser(int id, UserRequestDto userRequestDto);
        Task<StandardResponse<UserResponseDto>> DeleteUser(int id);
        Task<StandardResponse<UserResponseDto>> CreateUser(UserRequestDto userRequestDto);
        Task UploadProfileImage(FileStream file);
        //Search term will use searching
    }
}
