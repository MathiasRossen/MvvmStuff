using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmStuff.ViewModel
{
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        DefaultCommand closeCommand;

        public DefaultCommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new DefaultCommand(OnRequestClose);

                return closeCommand;
            }
        }

        protected WorkspaceViewModel()
        {
        }

        public event EventHandler RequestClose;

        public void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
