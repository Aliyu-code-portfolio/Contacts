using Contacts.Domain.Dtos.Request;
using Contacts.Domain.Dtos.Response;
using Microsoft.AspNetCore.Http;

namespace Contacts.Application.Services.Abstraction
{
    public interface IUserService
    {
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsers();
        Task<StandardResponse<UserResponseDto>> GetUserById(string id);
        Task<StandardResponse<UserResponseDto>> GetUserByEmail(string email);
        Task<StandardResponse<UserResponseDto>> UpdateUser(string id, UserRequestDto userRequestDto);
        Task<StandardResponse<UserResponseDto>> DeleteUser(string    id);
        Task<StandardResponse<UserResponseDto>> CreateUser(UserRequestDto userRequestDto);
        Task<StandardResponse<(bool,string)>> UploadProfileImage(string userId, IFormFile file);

        //Search term will use searching
        /*Task<StandardResponse<UserResponseDto>> UpdateProfilePicUser(UserRequestDto userRequestDto);*/
    }
}
