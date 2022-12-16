using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using wpfSBIFS.MVVM.Model;
using wpfSBIFS.MVVM.ViewModel;
/*
namespace wpfSBIFS.Commands
{
    public class GetGroupsCommand : AsyncCommandBase
    {
        private readonly ManageGroupsViewModel _viewModel;
        public readonly ServerConnectionAdapter _sva;

        public GetGroupsCommand(ManageGroupsViewModel viewModel,ServerConnectionAdapter sva)
            
        {
            _sva = sva;
            _viewModel = viewModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Username);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
          

            try
            {
                if (await _sva.DeleteUser(_viewModel.Username!,  _viewModel))
                {
                    _viewModel.Status = "Deletion successful!";
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
*/