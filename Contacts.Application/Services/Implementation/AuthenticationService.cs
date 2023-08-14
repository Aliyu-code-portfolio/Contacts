using AutoMapper;
using Contacts.Application.Services.Abstraction;
using Contacts.Domain.Dtos.Request;
using Contacts.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Application.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AuthenticationService(ILogger<AuthenticationService> logger, IMapper mapper, UserManager<User> userManager, IConfiguration config)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
        }

        public async Task<IdentityResult> RegisterUser(UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<User>(userRequestDto);
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, userRequestDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userRequestDto.Role);
            }
            return result;
        }
    }
}
