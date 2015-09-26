using System;
using System.Linq;
using System.Collections.Generic;
using CruiseDAL;
using CruiseDAL.DataObjects;
using System.Diagnostics;
using CruiseManager.Core.Models;
using CruiseManager.Core.ViewInterfaces;

namespace CruiseManager.Core.App
{
    /// <summary>
    /// The purpose of the window presenter is to display all the different forms of the application and
    /// provide a common place to for all the forms to access data and other infomation about the application state.
    /// it is the glue that binds the application together
    /// </summary>
    public abstract class WindowPresenter : IDisposable
    {
        public static WindowPresenter Instance { get; set; }

        public ApplicationController ApplicationController
        {
            get;
            set;
        }

        public MainWindow MainWindow { get; set; }

        public abstract string AskTemplateLocation();
        public abstract String AskCruiseSaveLocation();
        public abstract string AskOpenFileLocation();

        public abstract void ShowAboutDialog();
        public abstract void ShowCruiseLandingLayout();
        public abstract void ShowCustomizeCruiseLayout();
        public abstract void ShowCreateComponentsLayout();
        public abstract void ShowHomeLayout();
        public abstract void ShowImportTemplate();
        public abstract void ShowEditDesign();
        public abstract void ShowDataEditor();
        public abstract void ShowDataExportDialog(IList<TreeVM> Trees, IList<LogVM> Logs, IList<PlotDO> Plots, IList<CountTreeDO> Counts);
        public abstract void ShowEditWizard();
        public abstract void ShowCruiseWizardDialog();
        public abstract void ShowManageComponentsLayout();
        //public abstract void ShowOpenCruiseDialog();
        public abstract void ShowTemplateLandingLayout();

        public abstract void ShowSimpleErrorMessage(string errorMessage);

        public void ShowMessage(string message)
        {
            ShowMessage(message, null);
        }

        public abstract void ShowMessage(string message, string caption);

        public abstract Nullable<bool> AskYesNoCancel(String message, String caption);
        public abstract Nullable<bool> AskYesNoCancel(String message, String caption, Nullable<bool> defaultOption);

        public abstract void ShowWaitCursor();
        public abstract void ShowDefaultCursor();

        public abstract void Run();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.MainWindow.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~WindowPresenter() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
