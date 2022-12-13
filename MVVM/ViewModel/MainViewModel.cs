using System;
using System.Net.Http;
using System.Windows.Input;
using wpfSBIFS.Commands;
using wpfSBIFS.MVVM.Model;

namespace wpfSBIFS.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
       
        public ICommand HomeViewCommand { get; set; }
        public ICommand LoginViewCommand { get; set; }   
        public ICommand RegisterViewCommand { get; set; }
        public ICommand CloseCommand { get; }
        public ICommand DeleteUserViewCommand { get; set; }
        public ViewModelBase HomeVM { get; set; }

        public CloseCommand closeCommand;

        public ViewModelBase DeleteUserVM { get; set; }
        public ViewModelBase LoginVM { get; set; }
        public ViewModelBase RegisterVM { get; set; }


        HttpClient client;
        ServerConnectionAdapter sva;

        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            string hostName = "localhost";
            int port = 8080;
            client = new();
            client.Timeout = TimeSpan.FromSeconds(10);
            sva = new(hostName, port, client);
            CloseCommand = new CloseCommand();
            LoginVM = new LoginViewModel(this,sva);
            HomeVM = new HomeViewModel(sva);
            RegisterVM = new RegisterViewModel(sva);
            DeleteUserVM = new DeleteUserViewModel(sva);

            CurrentView = LoginVM;

            DeleteUserViewCommand = new RelayCommand(o =>
            {
                CurrentView = DeleteUserVM;
            });

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginVM;
            });
            RegisterViewCommand = new RelayCommand(o =>
            {
                CurrentView = RegisterVM;
            });
        }

        public void ChangeToHomeView()
        {
            CurrentView = HomeVM;
        }
    }
}
