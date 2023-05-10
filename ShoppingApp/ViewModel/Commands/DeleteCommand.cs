using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingApp.ViewModel.Commands
{
    public class DeleteCommand : ICommand
    {
        public ProductViewModel productViewModel { get; set; }
        public DeleteCommand(ProductViewModel productviewmodel)
        {
            productViewModel = productviewmodel;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            productViewModel.DeleteMethod();
        }
    }
}
