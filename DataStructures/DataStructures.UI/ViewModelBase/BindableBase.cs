using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataStructures.UI.ViewModelBase
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void SetProperty<T>(ref T propertyValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
