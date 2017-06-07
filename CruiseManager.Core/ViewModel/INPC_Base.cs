using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CruiseManager.Core.ViewModel
{
    public abstract class INPC_Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs ea)
        {
            PropertyChanged?.Invoke(this, ea);
        }

        public void SetValue<T>(T value, ref T target, [CallerMemberName] string propName = null)
        {
            target = value;
            OnPropertyChanged(propName);
        }
    }
}