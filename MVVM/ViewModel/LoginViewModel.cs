using System.Windows.Input;
using wpfSBIFS.Commands;
using wpfSBIFS.MVVM.Model;

namespace wpfSBIFS.MVVM.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        public readonly ServerConnectionAdapter _sva;

        private string? _username;
        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string? _password;
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string? _status;
        public string? Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(MainViewModel mainViewModel,ServerConnectionAdapter sva)
        {
            _sva = sva;
            _mainViewModel = mainViewModel;
            LoginCommand = new LoginCommand(this,_sva);
        }

        public void ChangeView()
        {
            _mainViewModel.ChangeToHomeView();
        }
    }
}
