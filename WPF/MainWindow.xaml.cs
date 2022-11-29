﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.CRUDForModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenCompanyWindow(object sender, RoutedEventArgs e)
        {
            Company company = new Company();
            company.ShowDialog();
        }

        private void OpenAddressWindow(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            address.ShowDialog();
        }
    }
}
