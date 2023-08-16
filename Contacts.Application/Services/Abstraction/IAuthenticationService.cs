using Contacts.Domain.Dtos.Request;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Application.Services.Abstraction
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRequestDto userRequestDto, string role);
        Task<bool> ValidateUser(UserLoginDto userLoginDto);
        Task<string> CreateToken();
    }
}
