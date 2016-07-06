namespace CruiseManager.Core.App
{
    public interface IUserSettings
    {
        bool? CreateSaleFolder { get; set; }

        string CruiseSaveLocation { get; set; }

        string TemplateSaveLocation { get; set; }

        string FileNameFormat { get; set; }

        string Region { get; set; }

        void Save();

        void Revert();

        void Reset();
    }
}