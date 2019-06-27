using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Services
{
    public abstract class NinjectContainerService :  IContainerService
    {
        public NinjectContainerService()
        {
            var kernel = new StandardKernel();
            RegisterTypes(kernel);
            Kernel = kernel;

        }

        protected StandardKernel Kernel { get; }

        protected abstract void RegisterTypes(StandardKernel kernel);


        public object Get(Type type)
        {
            return Kernel.Get(type);
        }
    }
}
