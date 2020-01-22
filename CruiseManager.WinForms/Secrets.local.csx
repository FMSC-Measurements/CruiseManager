Output.WriteLine($@"
namespace CruiseManager.WinForms
{{
    public static partial class Secrets
    {{
		static Secrets()
		{{
			APPCENTER_KEY_WINDOWS = ""{System.Environment.GetEnvironmentVariable("cruisemanager_appcenterr_key_windows") ?? ""}"";
		}}
    }}
}}
");