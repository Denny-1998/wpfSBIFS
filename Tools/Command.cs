using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpfSBIFS.Tools
{
    internal class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public Action<object> actionToInvoke;

        public bool CanExecute(object? parameter)
        {
            return actionToInvoke != null;
        }

        public void Execute(object? parameter)
        {
            if (CanExecute(parameter))
                this.actionToInvoke(parameter);
        }

        public Command(Action<object> actionToInvoke)
        {
            this.actionToInvoke = actionToInvoke;
        }
    }
}
