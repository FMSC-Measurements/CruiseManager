using CSM.App;

namespace CSM
{
    public interface IView
    {
        CommandBinding[] NavOptions { get; }
        CommandBinding[] ViewActions { get; }
    }
}
