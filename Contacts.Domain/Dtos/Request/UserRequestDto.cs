using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Domain.Dtos.Request
{
    public class UserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateOnly Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? ImageURL { get; set; }
    }
}
