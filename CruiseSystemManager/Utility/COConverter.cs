using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using CSM.Winforms;
using System.Windows;

namespace CSM.Utility 
{
    public class ProcessUpdateEventArgs
    {
        public string output { get; set; }
    }

    public delegate void ProcessUpdateEventHandler(ProcessUpdateEventArgs e);

    public class COConverter //: IDisposable
    {

        private delegate bool AsyncConvertCaller(String imputPath, String outputPath, ProcessUpdateEventHandler updateHandler);

        public static bool IsInstalled()
        {
            return System.IO.File.Exists(COConvertEXE);
        }

        //public readonly string COCONVERT_PATH = string.Format(
        //    "{0}\\utility\\COConverter.py", 
        //    Path.GetDirectoryName(Assembly.GetCallingAssembly().Location));

        //public static readonly string COConvertBat = String.Format(
        //    "{0}\\Utility\\RunCOConvert.bat", 
        //    CSM.WindowPresenter.GetApplicationDirectory());

        public static readonly string COConvertEXE = String.Format(
            "{0}\\Utility\\COConverter.exe",
            CSM.WindowPresenter.GetApplicationDirectory());


        public BindingList<String> Output { get; private set; }
        public String ErrorOutput { get; private set; }

        public static string ResolveConvertPath()
        {
            return System.IO.Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + "\\utility\\COConverter.py";
            //return System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\utility\\COConverter.py");
        }



        private AsyncConvertCaller _convertCallerHandel; 
        /// <summary>
        /// Begins a asyncronis process to convert a .crz file
        /// </summary>
        /// <param name="inputPath">.crz file to convert</param>
        /// <param name="outputPath">path to create the new .cruise file at</param>
        /// <param name="updateCaller">optional event handler to get called whenever the process progress updates</param>
        /// <param name="processDoneCallbackFunct">optional event handler to be called when the asyncronis process is done</param>
        /// <returns></returns>
        public IAsyncResult BenginConvert(String inputPath, String outputPath, ProcessUpdateEventHandler updateHandler,  AsyncCallback processDoneCallbackFunct)
        {
            _convertCallerHandel = new AsyncConvertCaller(this.Convert);

            return _convertCallerHandel.BeginInvoke(inputPath, outputPath, updateHandler, processDoneCallbackFunct, null);
        }

        /// <summary>
        /// Waits until the Asyncronis process finishes 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool EndConvert(IAsyncResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }
            if (_convertCallerHandel == null)
            {
                throw new ArgumentException("You must call BeginCreate first");
            }
            
            return _convertCallerHandel.EndInvoke(result);
        }

        public COConverter()
        {
            this.Output = new BindingList<string>();
            //PythonEngine.Initialize();
            //pyLock = PythonEngine.AcquireLock();
            //module = PythonEngine.ImportModule("Utility.COConverter");
        }

        private ProcessUpdateEventHandler _processUpdateEventHandle; 

        /// <summary>
        /// Runs a process to convert a .crz file to a .cruise file
        /// </summary>
        /// <param name="targetPath">.crz file to convert</param>
        /// <param name="outputPath">path to create the new .cruise file at</param>
        /// <param name="updateCaller">optional event handler to get called whenever the process progress updates</param>
        /// <returns></returns>
        public bool Convert(
            string targetPath, 
            string outputPath,
            ProcessUpdateEventHandler updateHandler)
        {
            try
            {
                targetPath = Path.GetFullPath(targetPath);                                      //convert paths to full paths
                outputPath = Path.GetFullPath(outputPath);

                if (File.Exists(targetPath) == false)
                {
                    Trace.TraceError("target path \"{0}\" can not be found", targetPath);
                    throw new FileNotFoundException("target path can not be found", targetPath);
                }


                if (File.Exists(COConvertEXE) == false)                                               //throw exception if we are unable to locate python.exe
                {
                    Trace.TraceError("COConverter can not be found");
                    throw new FileNotFoundException("COConverter can not be found", COConvertEXE);
                }

                if (this.Output.Count != 0) { this.Output.Clear(); }                            //reset output property

                using (Process myProcess = new Process())
                {

                    try
                    {
                        myProcess.StartInfo.UseShellExecute = true;
                        myProcess.StartInfo.FileName = COConvertEXE;
                        myProcess.StartInfo.Arguments =
                            String.Format(
                            " -w \"{0}\" \"{1}\" ",
                            targetPath,
                            outputPath);
                        myProcess.StartInfo.CreateNoWindow = false;

                        //myProcess.StartInfo.RedirectStandardInput = true;

                        //_processUpdateEventHandle = updateHandler;
                        //myProcess.StartInfo.RedirectStandardOutput = true;
                        //myProcess.StartInfo.RedirectStandardError = true;
                        //myProcess.OutputDataReceived +=
                        //    new DataReceivedEventHandler(OutputDataReceived);

                        myProcess.Start();
                        //StreamWriter inputWriter = myProcess.StandardInput;

                        //myProcess.BeginOutputReadLine();

                        //inputWriter.WriteLine();
                        //this.ErrorOutput = myProcess.StandardError.ReadToEnd();
                        myProcess.WaitForExit();

                    }
                    finally
                    {
                        _processUpdateEventHandle = null;
                    }

                    if (myProcess.ExitCode == 1)
                    {

                        return false;
                    }
                    else if (myProcess.ExitCode == 0)
                    {
                        return true;
                    }

                }
                return false;//fall through case, shouln't be reachable
            }
            catch(Exception e)
            {
                if (_processUpdateEventHandle != null)
                {
                    ProcessUpdateEventArgs args = new ProcessUpdateEventArgs();
                    args.output = e.ToString();
                    _processUpdateEventHandle(args);
                    return false;
                }
                else
                {
                    throw e;
                }
            }
        }

        void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) { return; }                                                     //if there's no data, return
            this.Output.Add(e.Data);                                                            //read the data to our output
            if (_processUpdateEventHandle != null)                                              //if user requested update even 
            {
                _processUpdateEventHandle(new ProcessUpdateEventArgs() { output = e.Data });   //call update event
            }
        }

    }
}
