using ShoppingApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {

        public UserViewModel registerviewmodel { get; set; }
        public RegisterCommand(UserViewModel userViewModel)
        {
            registerviewmodel = userViewModel;
        }
  
    
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            
            if (string.IsNullOrEmpty(registerviewmodel.FirstName)||
                string.IsNullOrEmpty(registerviewmodel.LastName) ||
                string.IsNullOrEmpty(registerviewmodel.Email) ||
                string.IsNullOrEmpty(registerviewmodel.Phone) ||
                string.IsNullOrEmpty(registerviewmodel.Address) ||
                string.IsNullOrEmpty(registerviewmodel.Password) )
            {
                return false;
            }
            else if (string.IsNullOrEmpty(registerviewmodel.Email)!=true)
            {
                Regex emailregex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = emailregex.Match(registerviewmodel.Email);
                Regex passwordregex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}$");
                Match pwdmatch=passwordregex.Match(registerviewmodel.Password);
                Regex phoneregex = new Regex("^[0-9]{10}$");
                Match phonematch=phoneregex.Match(registerviewmodel.Phone);
                if (match.Success != true || pwdmatch.Success!=true||phonematch.Success!=true )
                    return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            registerviewmodel.RegisterMethod();
        }
    }
}
