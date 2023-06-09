﻿using ShoppingApp.Model;
using ShoppingApp.View;
using ShoppingApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoppingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserViewModel obj = new UserViewModel();
            this.DataContext = obj;
        }
        public MainWindow(ObservableCollection<User> userList)
        {
            InitializeComponent();
            UserViewModel obj = new UserViewModel(userList);
            this.DataContext = obj;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow((DataContext as UserViewModel).UserList);
            registerWindow.Show();
            this.Close();
        }
    }
}
