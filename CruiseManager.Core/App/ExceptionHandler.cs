using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class ExceptionHandler : IExceptionHandler
    {
        //public static ExceptionHandler Instance { get; set; }


        public abstract bool Handel(Exception e);
        
    }
}
