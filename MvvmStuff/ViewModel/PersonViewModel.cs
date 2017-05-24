using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmStuff.Model;

namespace MvvmStuff.ViewModel
{
    public class PersonViewModel : WorkspaceViewModel
    {
        PersonRepository personRepository;
        DefaultCommand saveCommand;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DefaultCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DefaultCommand(ExecuteSave);

                return saveCommand;
            }
        }

        public bool IsSelected { get; set; }

        public override string DisplayName
        {
            get
            {
                return "Person creation";
            }
        }

        public PersonViewModel(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public void ExecuteSave()
        {

        }
    }
}
