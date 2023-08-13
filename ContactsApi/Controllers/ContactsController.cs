using Contacts.Application.Services.Abstraction;
using Contacts.Application.Services.Implementation;
using Contacts.Domain.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _contactService.GetAllContacts();
            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var result = await _contactService.GetContactById(id);
            return Ok(result);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetContactById(string email)
        {
            var result = await _contactService.GetContactByEmail(email);
            return Ok(result);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactRequestDto requestDto)
        {
            var result = await _contactService.CreateContact(requestDto);
            return Ok(result);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactRequestDto requestDto)
        {
            var result = await _contactService.UpdateContact(id, requestDto);
            return Ok(result);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactService.DeleteContact(id);
            return Ok(result);
        }
    }
}
