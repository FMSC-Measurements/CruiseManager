using System;

namespace CruiseManager.Core.App
{
    public interface IExceptionHandler
    {
        bool Handel(Exception e);
    }
}