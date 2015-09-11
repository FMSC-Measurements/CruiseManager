using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSM.Common
{
    public interface IExceptionHandler
    {
        void Handel(Exception e);
    }
}
