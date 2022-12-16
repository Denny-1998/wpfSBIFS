using System.Windows.Input;
using wpfSBIFS.Commands;
using wpfSBIFS.MVVM.Model;

namespace wpfSBIFS.MVVM.ViewModel
{
    public class DeleteUserViewModel : ViewModelBase
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

        public ICommand DeleteUserCommand { get; set; }

        public DeleteUserViewModel(ServerConnectionAdapter sva)
        {
            _sva = sva;
            DeleteUserCommand = new DeleteUserCommand(this, _sva);
            
        }
    }
}
