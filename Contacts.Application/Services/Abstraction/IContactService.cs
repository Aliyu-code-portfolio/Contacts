using Contacts.Domain.Dtos.Request;
using Contacts.Domain.Dtos.Response;
using Contacts.Shared.RequestParameter.Common;
using Contacts.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Application.Services.Abstraction
{
    public interface IContactService
    {
        Task<StandardResponse<(IEnumerable<ContactResponseDto> contacts, MetaData pagingData)>> GetAllContacts(ContactRequestInputParameter parameter);
        Task<StandardResponse<ContactResponseDto>> GetContactById(int id);
        Task<StandardResponse<ContactResponseDto>> GetContactByEmail(string email);
        Task<StandardResponse<ContactResponseDto>> UpdateContact(int id, ContactRequestDto contactRequestDto);
        Task<StandardResponse<ContactResponseDto>> DeleteContact(int id);
        Task<StandardResponse<ContactResponseDto>> CreateContact(ContactRequestDto contactRequestDto);

    }
}
