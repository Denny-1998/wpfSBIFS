using System.Windows.Input;
using wpfSBIFS.Commands;
using wpfSBIFS.MVVM.Model;

namespace wpfSBIFS.MVVM.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        
       
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

        public ICommand RegisterCommand { get; set; }
        
        public RegisterViewModel( ServerConnectionAdapter sva)

        {

            _sva = sva;
            RegisterCommand = new RegisterCommand(this, _sva);
        }
    }
}
