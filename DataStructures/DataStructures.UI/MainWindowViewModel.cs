using DataStructures.UI.Command;
using DataStructures.UI.ViewModels;
using DataStructures.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataStructures.UI
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly ICommand _onLoadedCommand;
        private IDataStructureViewModel _selectedDataStructure;

        public MainWindowViewModel()
        {
            _onLoadedCommand = new RelayCommand(OnLoaded);
            DataStructures = new ObservableCollection<IDataStructureViewModel>();
        }

        public ICommand OnLoadedCommand => _onLoadedCommand;

        public ObservableCollection<IDataStructureViewModel> DataStructures { get; set; }

        public IDataStructureViewModel SelectedDataStructure
        {
            get 
            { 
                return _selectedDataStructure; 
            }
            set 
            { 
                SetProperty(ref _selectedDataStructure, value); 
            }
        }

        private void OnLoaded(object obj)
        {
            DataStructures.Add(new DataStructureAxViewModel());
            DataStructures.Add(new DataStructureAyViewModel());
            SelectedDataStructure = DataStructures.First();
        }
    }
}
