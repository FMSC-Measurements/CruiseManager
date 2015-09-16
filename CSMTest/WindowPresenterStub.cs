﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CSM.Models;

namespace CSMTest
{
    public class WindowPresenterStub : CSM.Logic.IWindowPresenter
    {
        public DAL Database { get; set; }

        #region IWindowPresenter Members


        public CSM.ApplicationState AppState
        {
            get { throw new NotImplementedException(); }
        }

        public void HandleAboutClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleAppClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleCancelImportTemplateClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleCombineSaleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleCreateComponentsClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleCruiseCustomizeClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleEditViewCruiseClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleExportCruiseClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleFinishImportTemplateClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleHomePageClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleImportTemplateClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleManageComponensClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleCreateCruiseClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleReturnCruiseLandingClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleSaveClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleOpenFileClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ShowDataExportDialog(IList<TreeVM> Trees, IList<LogVM> Logs, IList<CruiseDAL.DataObjects.PlotDO> Plots, IList<CruiseDAL.DataObjects.CountTreeDO> Counts)
        {
            throw new NotImplementedException();
        }

        public void ShowWaitCursor()
        {
            throw new NotImplementedException();
        }

        public void ShowDefaultCursor()
        {
            throw new NotImplementedException();
        }

        public void ShowSimpleErrorMessage(string errorMessage)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IWindowPresenter Members


        public void HandleSaveAsClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public object GetTreeTDVList(TreeVM tree)
        {
            throw new NotImplementedException();
        }

        public string CruiseSaveLocation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string TemplateSaveLocation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<CSM.Utility.Setup.CruiseMethod> GetCruiseMethods(bool reconMethodsOnly)
        {
            throw new NotImplementedException();
        }

        public List<CSM.Utility.Setup.CruiseMethod> GetCruiseMethods(DAL database, bool reconMethodsOnly)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IWindowPresenter Members

        public object GetSampleGroupsByStratum(long? st_cn)
        {
            throw new NotImplementedException();
        }


        public void ShowCruiseLandingLayout()
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message, string caption)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IWindowPresenter Members

        public void ShowAboutDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowCustomizeCruiseLayout()
        {
            throw new NotImplementedException();
        }

        public void ShowCreateComponentsLayout()
        {
            throw new NotImplementedException();
        }

        public void ShowHomeLayout()
        {
            throw new NotImplementedException();
        }

        public void ShowImportTemplate()
        {
            throw new NotImplementedException();
        }

        public void ShowEditDesign()
        {
            throw new NotImplementedException();
        }

        public void ShowDataEditor()
        {
            throw new NotImplementedException();
        }

        public void ShowEditWizard()
        {
            throw new NotImplementedException();
        }

        public void ShowCruiseWizardDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowManageComponentsLayout()
        {
            throw new NotImplementedException();
        }

        public void ShowOpenCruiseDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowTemplateLandingLayout()
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.DialogResult AskYesNoCancel(string message, string caption)
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.DialogResult AskYesNoCancel(string message, string caption, System.Windows.Forms.DialogResult defaultOption)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IApplicationController Members

        public CSM.Common.IExceptionHandler ExceptionHandler
        {
            get { throw new NotImplementedException(); }
        }

        public string[] RecentFiles
        {
            get { throw new NotImplementedException(); }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SaveAs()
        {
            throw new NotImplementedException();
        }

        public void OpenFile(string filePath)
        {
            throw new NotImplementedException();
        }

        List<string> CSM.Logic.IApplicationController.GetCruiseMethods(bool reconMethodsOnly)
        {
            throw new NotImplementedException();
        }

        List<string> CSM.Logic.IApplicationController.GetCruiseMethods(DAL database, bool reconMethodsOnly)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
