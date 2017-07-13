using System;
using System.Collections.Generic;
using System.Text;

namespace DanielWambura.ApplicationCore.Services
{
    public interface IAppLogger<T>
    {
        void LogWarning(string message, params object[] args);
    }
}
