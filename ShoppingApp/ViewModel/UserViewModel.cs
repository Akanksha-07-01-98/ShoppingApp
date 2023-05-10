using ShoppingApp.Model;
using ShoppingApp.View;
using ShoppingApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoppingApp.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<User> UserList { get; set; }

        public UserViewModel(ObservableCollection<User> userList)
        {
            UserList = userList;
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);

        }
        public UserViewModel()
        {
            UserList = new ObservableCollection<User>();
            UserList.Add(
                new User
                {
                    FirstName = "Akanksha",
                    LastName = "Singh",
                    Email = "ak@gmail.com",
                    Phone = "9876543210",
                    Address = "Kolkata",
                    Password = "123"
                });
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);

        }

        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// This command is used to implement the registration functionality
        /// </summary>
        public RegisterCommand RegisterCommand { get; set; }

        public void RegisterMethod()
        {
            UserList.Add(new User { FirstName = FirstName, LastName = LastName, Email = Email, Phone = Phone, Address = Address, Password = Password });
            MessageBox.Show("User added successfully");
            MainWindow mainWindow = new MainWindow(UserList);
            mainWindow.Show();
            var registerwindow = Application.Current.Windows[0];
            registerwindow.Close();
        }

        /// <summary>
        /// This method is used to check the login credentials.
        /// </summary>
        public LoginCommand LoginCommand { get; set; }
        public void LoginMethod()
        {
            var loginsuccess = false;
            foreach (var user in UserList)
            {
                if (FirstName == user.FirstName && Password == user.Password)
                {
                    ProductWindow productWindow = new ProductWindow();
                    productWindow.Show();
                    loginsuccess = true;
                    var loginwindow = Application.Current.Windows[0];
                    loginwindow.Close();
                }
            }

            if (loginsuccess == false)
            {
                MessageBox.Show("Not a valid user!");
            }
        }
        /// <summary>
        /// This is used to define the property change method
        /// </summary>
        /// <param name="propertyName">This takes user personal details as each parameter</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
