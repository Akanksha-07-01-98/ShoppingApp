using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public UserViewModel userviewmodel{get; set;}
        public LoginCommand(UserViewModel userViewModel)
        {
            userviewmodel = userViewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            
            if (string.IsNullOrEmpty(userviewmodel.FirstName) || (string.IsNullOrEmpty(userviewmodel.Password)))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            userviewmodel.LoginMethod();
        }
    }
}
