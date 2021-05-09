using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataStructures.UI.ViewModelBase
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (property.Equals(value))
                return;

            property = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
