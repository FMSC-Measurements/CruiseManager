using CruiseManager.App;

namespace CruiseManager
{
    public interface IView
    {
        CommandBinding[] NavOptions { get; }
        CommandBinding[] ViewActions { get; }
    }
}
