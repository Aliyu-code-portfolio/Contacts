using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Contacts.Application.Services.Abstraction;
using Contacts.Domain.Dtos.Request;
using Contacts.Domain.SharedModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Application.Services.Implementation
{
    public class PhotoService:IPhotoService
    {
        public IConfiguration Configuration { get;}
        private CloudinarySettings _cloudinarySettings;
        private Cloudinary _cloudinary;
        public PhotoService(IConfiguration configuration)
        {
            Configuration = configuration;
            _cloudinarySettings.CloudName = Configuration.GetSection("CloudinarySettings")["CloudName"];
            _cloudinarySettings.ApiKey = Configuration.GetSection("CloudinarySettings")["ApiKey"];
            _cloudinarySettings.ApiSecret = Configuration.GetSection("CloudinarySettings")["ApiSecret"];
            Account account = new Account(_cloudinarySettings.CloudName
                , _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret
                );
            _cloudinary = new Cloudinary(account);
        }

        public string AddPhotoForUser(int userId, PhotoRequestDto photoRequestDto)
        {
            var file = photoRequestDto.File;
            var uploadResult = new ImageUploadResult();
            throw new NotImplementedException();
        }
    }
}
