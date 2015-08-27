using System;
using System.Collections.Generic;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CSM.DataTypes;
using CSM.Utility.Setup;

namespace CSM.Logic
{
    public interface IWindowPresenter
    {

        DAL Database { get; }
        ApplicationState AppState { get; }
        string CruiseSaveLocation { get; set; }
        string TemplateSaveLocation { get; set; }
        string[] RecentFiles { get; }

        void OpenFile(String filePath);

        void HandleAboutClick(object sender, EventArgs e);
        void HandleAppClosing(object sender, System.Windows.Forms.FormClosingEventArgs e);
        void HandleCancelImportTemplateClick(object sender, EventArgs e);
        void HandleCombineSaleClick(object sender, EventArgs e);
        void HandleCreateComponentsClick(object sender, EventArgs e);
        void HandleCruiseCustomizeClick(object sender, EventArgs e);
        void HandleEditViewCruiseClick(object sender, EventArgs e);
        void HandleExportCruiseClick(object sender, EventArgs e);
        void HandleFinishImportTemplateClick(object sender, EventArgs e);
        void HandleHomePageClick(object sender, EventArgs e);
        void HandleImportTemplateClick(object sender, EventArgs e);
        void HandleManageComponensClick(object sender, EventArgs e);
        void HandleCreateCruiseClick(object sender, EventArgs e);
        void HandleReturnCruiseLandingClick(object sender, EventArgs e);
        void HandleSaveClick(object sender, EventArgs e);
        void HandleSaveAsClick(object sender, EventArgs e);
        void HandleOpenFileClick(object sender, EventArgs e);

        void ShowDataExportDialog(IList<TreeVM> Trees, IList<LogVM> Logs, IList<PlotDO> Plots, IList<CountTreeDO> Counts);
        void ShowSimpleErrorMessage(string errorMessage);
        void ShowCruiseLandingLayout();

        void ShowMessage(string message, string caption);


        void ShowWaitCursor();
        //void HideWaitCursor();
        void ShowDefaultCursor();

        //void OnActivePresentorChanged();

        List<string> GetCruiseMethods(bool reconMethodsOnly);
        List<string> GetCruiseMethods(DAL database, bool reconMethodsOnly);
        object GetTreeTDVList(TreeVM tree);
        object GetSampleGroupsByStratum(long? st_cn);

    }
}
