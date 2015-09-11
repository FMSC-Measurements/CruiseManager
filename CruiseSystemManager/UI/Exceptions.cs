using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSM.UI
{
    public class UserFacingException : Exception
    {
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

}
