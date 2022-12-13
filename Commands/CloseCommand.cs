using System;
using System.Windows;
using System.Windows.Input;

namespace wpfSBIFS.Commands
{
    public class CloseCommand : ICommand
    {
        // Implement the CanExecute methoid
        public bool CanExecute(object parameter)
        {
            // returning true so that the button is always enabled
            return true;
        }

        // implementing the ICommand executed method
        public void Execute(object parameter)
        {
           
            //shutdown everything
            Application.Current.Shutdown();
        }

        // Declare the CanExecuteChanged event.
        public event EventHandler CanExecuteChanged;

      
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
