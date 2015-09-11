using System;
using System.Collections.Generic;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CSM.DataTypes;
using CSM.Utility.Setup;
using System.Windows.Forms;

namespace CSM.Logic
{
    public interface IWindowPresenter : IApplicationController
    {
           
        void ShowAboutDialog();
        void ShowCruiseLandingLayout();
        void ShowCustomizeCruiseLayout();
        void ShowCreateComponentsLayout();
        void ShowHomeLayout();
        void ShowImportTemplate();
        void ShowEditDesign();
        void ShowDataEditor();
        void ShowDataExportDialog(IList<TreeVM> Trees, IList<LogVM> Logs, IList<PlotDO> Plots, IList<CountTreeDO> Counts);
        void ShowEditWizard();
        void ShowCruiseWizardDialog();
        void ShowManageComponentsLayout();
        void ShowOpenCruiseDialog();        
        void ShowTemplateLandingLayout();

        void ShowSimpleErrorMessage(string errorMessage);
        void ShowMessage(string message, string caption);

        DialogResult AskYesNoCancel(String message, String caption);
        DialogResult AskYesNoCancel(String message, String caption, DialogResult defaultOption);

        void ShowWaitCursor();
        //void HideWaitCursor();
        void ShowDefaultCursor();


        //void OnActivePresentorChanged();
    }
}
