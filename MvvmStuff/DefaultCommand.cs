using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmStuff
{
    public class DefaultCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public DefaultCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public DefaultCommand(Action execute)
            :this(execute, null)
        {
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;
            return canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
