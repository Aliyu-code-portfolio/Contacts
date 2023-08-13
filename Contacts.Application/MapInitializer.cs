using AutoMapper;
using Contacts.Domain.Dtos.Request;
using Contacts.Domain.Dtos.Response;
using Contacts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Application
{
    public class MapInitializer:Profile
    {
        public MapInitializer()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequestDto, User>();
            CreateMap<Contact,ContactResponseDto>();
            CreateMap<ContactRequestDto, Contact>();
        }
    }
}
