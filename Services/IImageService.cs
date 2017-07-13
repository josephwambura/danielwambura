using System;
using System.Collections.Generic;
using System.Text;

namespace DanielWambura.ApplicationCore.Services
{
    public interface IImageService
    {
        byte[] GetImageBytesById(int id);
    }
}
