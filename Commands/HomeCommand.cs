using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpfSBIFS.MVVM.Model;
using wpfSBIFS.MVVM.ViewModel;

namespace wpfSBIFS.Commands
{
    public class HomeCommand : AsyncCommandBase
    {
        public readonly ServerConnectionAdapter _sva;
        public HomeCommand(ServerConnectionAdapter sva)
        {
            
            _sva = sva;
           
        }
        // Implement the CanExecute methoid
        public override bool CanExecute(object parameter)
        {
            // returning true so that the button is always enabled
            return true;
        }

        // implementing the ICommand executed method
        
        public override async Task<string> ExecuteAsync(object? parameter)
        {

          
            int userCount = await _sva.GetUserCount();
            //convert int to string
            return userCount.ToString();

        }

        // Declare the CanExecuteChanged event.

    }
}
