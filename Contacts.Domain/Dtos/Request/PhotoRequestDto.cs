using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Domain.Dtos.Request
{
    public class PhotoRequestDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
    }
}
