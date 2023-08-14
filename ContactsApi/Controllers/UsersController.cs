using Contacts.Application.Services.Abstraction;
using Contacts.Domain.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }
        
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserById(string email)
        {
            var result = await _userService.GetUserByEmail(email);
            return Ok(result);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDto requestDto)
        {
            var result = await _userService.CreateUser(requestDto);
            return Ok(result);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequestDto requestDto)
        {
            var result = await _userService.UpdateUser(id, requestDto);
            return Ok(result);
        }

        /////////
        [HttpPatch("{id}")]
        public async Task<IActionResult> UploadProfileImg(int id, [FromBody] UserRequestDto requestDto)
        {
            var result = await _userService.UpdateUser(id, requestDto);
            return Ok(result);
        }
        /////////
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }
    }
}
