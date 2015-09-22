using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.App
{
    public class UserFacingException : Exception
    {
        public UserFacingException() : base() { }

        public UserFacingException(String message) : base(message) { }

        public UserFacingException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class DataValidationException : UserFacingException
    {
        public Object DataObject { get; set; }
        public DataValidationException(object obj, string message, Exception innerException)
            : base(message, innerException)
        {
            this.DataObject = obj;
        }

        public DataValidationException(string message, Exception innerException)
            : base(message, innerException) { }

    }

    public class ProtectedFieldAccessException : UserFacingException
    {
        public ProtectedFieldAccessException(String fieldName, Type type, string message)
        {
            throw new NotImplementedException();
        }

        public ProtectedFieldAccessException(String fieldName, Type type)
        {
            throw new NotImplementedException();
        }
    }

}
