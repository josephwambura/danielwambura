using System;
using System.Collections.Generic;
using System.Text;

namespace DanielWambura.ApplicationCore.Exceptions
{
    public class DawaImageImageMissingException : Exception
    {
        public DawaImageImageMissingException(string message,
            Exception innerException = null)
            : base(message, innerException: innerException)
        {
        }
        public DawaImageImageMissingException(Exception innerException)
            : base("No image found for the provided id.",
                  innerException: innerException)
        {
        }
    }
}
