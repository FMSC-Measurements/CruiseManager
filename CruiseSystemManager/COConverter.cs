using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Python.Runtime;
using Python;

namespace CruiseSystemManager
{
    public class COConverter : IDisposable
    {
        private IntPtr pyLock;
        private PyObject module;

        public COConverter()
        {
            PythonEngine.Initialize();
            pyLock = PythonEngine.AcquireLock();
            module = PythonEngine.ImportModule("COConverter.COConverter");
        }

        public bool Run(string targetPath, string outputPath)
        {
            var returnVal = false;

            var args = new PyObject[2];
            args[0] = new PyString(targetPath);
            args[1] = new PyString(outputPath);
            PyObject pyVal = module.InvokeMethod("Run", args);
            bool.TryParse(pyVal.ToString(),out returnVal);

            return returnVal;
        }

        public void Dumplog(string path)
        {
            var args = new PyString[1];
            args[0] = new PyString(path);
            //args[1] = new PyString(level);
            module.InvokeMethod("dumpLog", args);


        }


        #region IDisposable Members

        public void Dispose()
        {
            PythonEngine.ReleaseLock(pyLock);
            PythonEngine.Shutdown();
            module = null;
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
