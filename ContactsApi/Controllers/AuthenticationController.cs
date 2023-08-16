using Contacts.Application.Services.Abstraction;
using Contacts.Domain.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // POST api/<AuthenticationController>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto requestDto)
        {
           var result =await _authenticationService.RegisterUser(requestDto, role:"User");
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRequestDto requestDto)
        {
           var result =await _authenticationService.RegisterUser(requestDto, role: "Admin");
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto requestDto)
        {
            if(!await _authenticationService.ValidateUser(requestDto))
            {
                return Unauthorized();
            }
            return Ok(new { token = await _authenticationService.CreateToken() });
        }
    }
}
