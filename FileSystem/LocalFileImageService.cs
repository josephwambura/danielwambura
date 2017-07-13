using DanielWambura.ApplicationCore.Exceptions;
using DanielWambura.ApplicationCore.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DanielWambura.Infrastructure.FileSystem
{
    public class LocalFileImageService : IImageService
    {
        private readonly IHostingEnvironment _env;

        public LocalFileImageService(IHostingEnvironment env)
        {
            _env = env;
        }
        public byte[] GetImageBytesById(int id)
        {
            try
            {
                var contentRoot = _env.ContentRootPath + "//Uploads";
                var path = Path.Combine(contentRoot, id + ".png");
                return File.ReadAllBytes(path);
            }
            catch (FileNotFoundException ex)
            {
                throw new DawaImageImageMissingException(ex);
            }
        }
    }
}
