using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using wpfSBIFS.MVVM.Model;
using wpfSBIFS.MVVM.ViewModel;

namespace wpfSBIFS.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _viewModel;
        public readonly ServerConnectionAdapter _sva;

        public RegisterCommand(RegisterViewModel viewModel, ServerConnectionAdapter sva)
        {
            _viewModel = viewModel;
            _sva = sva;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
        

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Username) &&
                !string.IsNullOrEmpty(_viewModel.Password);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            
            

            try
            {
                if (await _sva.Register(_viewModel.Username!, _viewModel.Password!,  _viewModel))
                {
                    _viewModel.Status = "Registration successful!";
                }
            }
            catch (TaskCanceledException)
            {
                _viewModel.Status = "The request timed out!";

            }
            catch (HttpRequestException)
            {
                _viewModel.Status = "The server is not reachable!";
            }
            
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
