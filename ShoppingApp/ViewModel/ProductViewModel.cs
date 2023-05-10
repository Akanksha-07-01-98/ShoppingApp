using Newtonsoft.Json;
using ShoppingApp.Model;
using ShoppingApp.View;
using ShoppingApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ShoppingApp.ViewModel
{
    public class ProductViewModel : NotifyPropertyChangedHandler
    {
        public ObservableCollection<Product> productList { get; set; }


        private Product product;

        public List<Product> Items { get; set; }

        public ProductViewModel(ObservableCollection<Product> productlist)
        {
            productList = productlist;
            GetJsonData();
            AddToCartCommand = new AddToCartCommand(this);
            CheckoutCommand = new CheckoutCommand(this);
            UpdateCommand = new UpdateCommand(this);
            DeleteCommand = new DeleteCommand(this);
            InvoiceCommand = new InvoiceCommand(this);
            BackToProductsCommand = new BackToProductsCommand(this);
            quantityCollection = new ObservableCollection<int>();
            quantityCollection.Add(1);
            quantityCollection.Add(2);
            quantityCollection.Add(3);
            quantityCollection.Add(4);
            quantityCollection.Add(5);
        }
        public ProductViewModel()
        {
            product = new Product();
            GetJsonData();
            AddToCartCommand = new AddToCartCommand(this);
            CheckoutCommand = new CheckoutCommand(this);
            UpdateCommand = new UpdateCommand(this);
            DeleteCommand = new DeleteCommand(this);
            InvoiceCommand = new InvoiceCommand(this);
            BackToProductsCommand = new BackToProductsCommand(this);
            quantityCollection = new ObservableCollection<int>();
            quantityCollection.Add(1);
            quantityCollection.Add(2);
            quantityCollection.Add(3);
            quantityCollection.Add(4);
            quantityCollection.Add(5);
            productList = new ObservableCollection<Product>();
        }

        /// <summary>
        /// This is used to select the product from the products page
        /// </summary>
        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                NotifyPropertyChanged("SelectedProduct");

            }
        }
        /// <summary>
        /// This is used to deserialize the json product data into list of products
        /// </summary>
        private void GetJsonData()
        {
            string json = System.IO.File.ReadAllText("ProductData.json");
            Items = JsonConvert.DeserializeObject<List<Product>>(json);
        }
        /// <summary>
        /// The following command is used to add a product to cart using "Add to cart" button.
        /// </summary>
        public AddToCartCommand AddToCartCommand { get; set; }

        public void AddToCartMethod()
        {
            if (SelectedProduct != null && SelectedProduct.Quantity <= 5 && SelectedProduct.Quantity >= 1)
            {
                productList.Add(SelectedProduct);
                MessageBox.Show("Product added to cart successfully");
            }
            else
            {
                MessageBox.Show("No product selected or quantity is greater than 5 or less than 1");
            }
        }
        /// <summary>
        /// The following command is used to navitage to cart window after all the products are added using "Checkout" button.
        /// </summary>
        public CheckoutCommand CheckoutCommand { get; set; }

        public void CheckoutMethod()
        {
            CartWindow cartWindow = new CartWindow(productList);
            cartWindow.Show();
            var productwindow = Application.Current.Windows[0];
            productwindow.Close();

        }
        /// <summary>
        /// This is used to select the product from cart page so that we can edit the quantity or remove product from cart.
        /// </summary>
        private Product selectedcartProduct;
        public Product SelectedCartProduct
        {
            get { return selectedcartProduct; }
            set
            {
                selectedcartProduct = value;
                NotifyPropertyChanged("SelectedCartProduct");

            }
        }

        public ObservableCollection<int> quantityCollection { get; set; }
        private int cartquantity;

        public int CartQuantity
        {
            get { return cartquantity; }
            set { cartquantity = value; NotifyPropertyChanged("CartQuantity"); }
        }

        /// <summary>
        /// The following command is used to edit the quantity of product on the cart page using update button.
        /// </summary>
        public UpdateCommand UpdateCommand { get; set; }

        public void UpdateMethod()
        {
            if (SelectedCartProduct != null)
            {
                SelectedCartProduct.Quantity = cartquantity;
            }
            else
            {
                MessageBox.Show("No product selected");
            }

        }
        /// <summary>
        /// The following command is used to delete product added on the cart page using delete button.
        /// </summary>
        public DeleteCommand DeleteCommand { get; set; }

        public void DeleteMethod()
        {
            if (SelectedCartProduct != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete the selected product?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    productList.Remove(this.selectedcartProduct);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("No product is selected");
            }

        }

        /// <summary>
        /// This will calculate the total amount that needs to be paid on click "Invoice" button
        /// </summary>
        public InvoiceCommand InvoiceCommand { get; set; }
        public void InvoiceMethod()
        {

            double totalamount = 0;
            foreach (var product in productList)
            {
                totalamount += (product.Quantity) * (product.Price);
            }
            string total = totalamount.ToString();
            MessageBox.Show("Total amount paid: Rs." + total);
        }
        /// <summary>
        /// This command is used to navigate back to products page from cart page.s
        /// </summary>
        public BackToProductsCommand BackToProductsCommand { get; set; }
        public void BackToProductsMethod()
        {

            var cartwindow = Application.Current.Windows[0];
            ProductWindow prodwin = new ProductWindow(productList);
            prodwin.Show();
            cartwindow.Close();

        }


    }
}
