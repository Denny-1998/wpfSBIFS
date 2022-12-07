using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpfSBIFS.Core;

namespace wpfSBIFS.ViewModel
{
    class AdminPanelViewModel : ObservableObject
    {
        public HomeViewModel HomeVM { get; set; }
        
        public object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public AdminPanelViewModel()
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
            


        }
    }
}
