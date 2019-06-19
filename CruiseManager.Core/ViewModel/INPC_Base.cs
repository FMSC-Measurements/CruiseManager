using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CruiseManager.Core.ViewModel
{
    public abstract class INPC_Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propName = null)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propName));
        }

        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs ea)
        {
            PropertyChanged?.Invoke(this, ea);
        }

        public void SetProperty<T>(ref T target, T value, [CallerMemberName] string propName = null)
        {
            target = value;
            RaisePropertyChanged(propName);
        }
    }
}