using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmStuff.ViewModel
{
    public class CommandViewModel : ViewModelBase
    {
        public DefaultCommand Command { get; private set; }

        public CommandViewModel(string displayName, DefaultCommand command)
        {
            base.DisplayName = displayName;
            Command = command;
        }
    }
}
