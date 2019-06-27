using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Services
{
    public interface IContainerService
    {
        object Get(Type type);
    }
}
