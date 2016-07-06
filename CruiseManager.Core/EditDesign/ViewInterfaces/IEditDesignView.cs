using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.EditDesign.ViewInterfaces
{
    public interface IEditDesignView : IView
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