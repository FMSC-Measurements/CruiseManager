namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ITallyEditPanel
    {
        TallySetupStratum_Base Stratum { get; set; }

        void EndEdits();
    }
}