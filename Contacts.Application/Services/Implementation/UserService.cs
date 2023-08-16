using AutoMapper;
using Contacts.Application.Services.Abstraction;
using Contacts.Domain.Dtos.Request;
using Contacts.Domain.Dtos.Response;
using Contacts.Domain.Models;
using Contacts.Infrastructure.Repositories.UOW.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Contacts.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPhotoService _photoService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _photoService = photoService;
        }

        public async Task<StandardResponse<UserResponseDto>> CreateUser(UserRequestDto userRequestDto)
        {
            _logger.LogInformation("Creating user");
            var user = _mapper.Map<User>(userRequestDto);
            _logger.LogInformation("Adding user to the database");
            _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"User {user.Id} saved to the database successfully");
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success("User created successfully", userDto, 201);
        }

        public async Task<StandardResponse<UserResponseDto>> DeleteUser(string id)
        {
            _logger.LogInformation($"Checking if user with id {id} exists");
            var user =await _unitOfWork.UserRepository.GetUserById(id);
            if(user is null) 
            {
                _logger.LogError("User not found in the database. Aborting delete");
                return StandardResponse<UserResponseDto>.Failed("User not found in the database");
            }
            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync();
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success($"Successfully deleted a user {user.FirstName}", userDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllUsers();
            var usersDtos = _mapper.Map<IEnumerable<UserResponseDto>>(users);
            return StandardResponse<IEnumerable<UserResponseDto>>.Success("Successfully retrieved all users",usersDtos,200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(email);
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success("Successfully retrieved a user", userDto, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetUserById(string id)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(id);
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success("Successfully retrieved a user", userDto, 200);
        }

        public Task<StandardResponse<UserResponseDto>> UpdateProfilePicUser(UserRequestDto userRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<StandardResponse<UserResponseDto>> UpdateUser(string id, UserRequestDto userRequestDto)
        {
            var userExists =await _unitOfWork.UserRepository.GetUserById(id);
            if (userExists is null)
            {
                _logger.LogError("User not found in the database. Aborting update");
                return StandardResponse<UserResponseDto>.Failed("User not found in the database");
            }
            var user = _mapper.Map<User>(userRequestDto);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success($"Successfully deleted a user {user.FirstName}", userDto, 200);
        }

        public async Task<StandardResponse<(bool,string)>> UploadProfileImage(string userId, IFormFile file)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(userId);
            if (user is null)
            {
                _logger.LogWarning($"No user with id {userId}");
                return StandardResponse<(bool, string)>.Failed("No user found",  406);
            }
            string url = _photoService.AddPhotoForUser(userId, file);
            if(string.IsNullOrWhiteSpace(url))
                return StandardResponse<(bool, string)>.Failed("Failed to upload", 500);
            user.ImageURL= url;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
            return StandardResponse<(bool, string)>.Success("Successfully uploaded image", (false,url), 204);
        }
    }
}
