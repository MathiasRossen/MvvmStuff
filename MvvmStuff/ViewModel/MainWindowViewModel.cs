using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using MvvmStuff.Model;

namespace MvvmStuff.ViewModel
{
    public class MainWindowViewModel
    {
        PersonRepository personRepository;
        ObservableCollection<WorkspaceViewModel> workspaces;

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (workspaces == null)
                {
                    workspaces = new ObservableCollection<WorkspaceViewModel>();
                    workspaces.CollectionChanged += OnWorkspacesChanged;
                }

                return workspaces;
            }
        }

        public List<CommandViewModel> Commands { get; private set; }

        public MainWindowViewModel()
        {
            personRepository = new PersonRepository();
            Commands = new List<CommandViewModel>();
            Commands.Add(new CommandViewModel("View Persons", new DefaultCommand(ExecuteViewPersons)));
        }

        public void ExecuteViewPersons()
        {
            PersonViewModel workspace = new PersonViewModel(personRepository);
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);

            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            Workspaces.Remove(workspace);
        }
    }
}
