using DataStructures.UI.Command;
using DataStructures.UI.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataStructures.UI
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly ICommand _onLoadedCommand;
        private string _exampleText = "Some text";

        public MainWindowViewModel()
        {
            _onLoadedCommand = new RelayCommand(OnLoaded);
        }

        public ICommand OnLoadedCommand => _onLoadedCommand;

        public string ExampleText
        {
            get
            {
                return _exampleText;
            }
            set
            {
                SetProperty(ref _exampleText, value);
            }
        }

        private void OnLoaded(object obj)
        {
        }
    }
}
