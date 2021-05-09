using DataStructures.UI.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.UI
{
    public class MainWindowViewModel : BindableBase
    {
        private string _exampleText = "Some text";

        public MainWindowViewModel()
        {
        }

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
    }
}
