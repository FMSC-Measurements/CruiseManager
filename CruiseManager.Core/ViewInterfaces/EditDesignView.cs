using CruiseManager.Core.EditDesign;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface EditDesignView : IView
    {
        new DesignEditorPresentor ViewPresenter { get; set; }

        //BindingSource SampleGroupBindingSource { get; set; }
        //BindingSource SampleGroup_TDVBindingSource { get; set; }
        //BindingSource StrataBindingSource { get; set; }
        //BindingSource CuttingUnitsBindingSource { get; set; }

        void UpdateSampleGroups(object samplegroups);
        void UpdateSampleGroupTDVs(object tdvs);
        void UpdateStrata(object strata);
        void UpdateCuttingUnits(object cuttingUnits);


        void BindSetup();
        void BindData();
        void EndEdits();
    }
}
