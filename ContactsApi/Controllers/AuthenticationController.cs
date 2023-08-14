using Contacts.Application.Services.Abstraction;
using Contacts.Domain.Dtos.Request;
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
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto requestDto)
        {
           var result =await _authenticationService.RegisterUser(requestDto);
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
        
        /*[HttpPost]
        public Task<IActionResult> LoginUser([FromBody] UserRequestDto requestDto)
        {

        }*/
    }
}
