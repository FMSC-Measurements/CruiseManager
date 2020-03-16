namespace CruiseManager
{
    public static class AnalyticsEvents
    {
        public const string SUPERVISORLOGIN_SUCCESS = "SupervisorLogin_Success";
        public const string SUPERVISORLOGIN_FAIL = "SupervisorLogin_Fail";

        public const string FEATURE_EDITCRUISEWIZARD = "Feature_EditCruiseWizard";
        public const string FEATURE_DATAEXPORT = "Feature_DataExport";

        public const string COMPONENTS_CREATE = "Components_Create";

        public const string MERGE_START = "Merge_Start";
        public const string MERGE_DONE = "Merge_Done";
        public const string MERGE_CANCEL = "Merge_Cancel";
        public const string MERGE_FAIL = "Merge_Fail";
    }
}