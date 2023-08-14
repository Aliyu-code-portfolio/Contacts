using Contacts.Domain.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Application.Services.Abstraction
{
    public interface IPhotoService
    {
        string AddPhotoForUser(int userId, PhotoRequestDto photoRequestDto);
    }
}
