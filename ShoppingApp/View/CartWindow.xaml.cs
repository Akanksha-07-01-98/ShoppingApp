using ShoppingApp.Model;
using ShoppingApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShoppingApp.View
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow(ObservableCollection<Product> productList)
        {
            InitializeComponent();
            ProductViewModel obj = new ProductViewModel(productList);
            this.DataContext = obj;
            productlistview.ItemsSource = obj.productList;
        }


    }
}
