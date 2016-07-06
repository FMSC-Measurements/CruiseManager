namespace CruiseManager.Core.ViewModel
{
    public interface ISaveHandler
    {
        bool HandleSave();

        bool HasChangesToSave { get; }
    }
}