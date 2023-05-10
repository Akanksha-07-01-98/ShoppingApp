using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingApp.ViewModel.Commands
{
    public class BackToProductsCommand : ICommand
    {
        public ProductViewModel productViewModel { get; set; }
        public BackToProductsCommand(ProductViewModel productviewmodel)
        {
            productViewModel = productviewmodel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            productViewModel.BackToProductsMethod();
        }
    }
}
