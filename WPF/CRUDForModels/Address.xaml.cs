using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF.CRUDForModels
{
    /// <summary>
    /// Interaction logic for Address.xaml
    /// </summary>
    public partial class Address : Window
    {
        public Address()
        {
            InitializeComponent();
            GetAddress();

            AddNewAddressGrid.DataContext = NewAddress;
        }

        static IMapper Mapper = SetupMapper();
        AddressDTO NewAddress = new AddressDTO();
        AddressDTO selectedAddress = new AddressDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(AddressDAL).Assembly)
                );
            return config.CreateMapper();
        }

        private void GetAddress()
        {
            var dal = new AddressDAL(Mapper);

            var addressesList = dal.GetAllAddresses();
            AddressDG.ItemsSource = addressesList;
        }

        private void AddAddress(object s, RoutedEventArgs e)
        {
            var dal = new AddressDAL(Mapper);

            NewAddress = dal.CreateAddress(NewAddress);

            GetAddress();
            NewAddress = new AddressDTO();
            AddNewAddressGrid.DataContext = NewAddress;
        }

        private void DeleteAddress(object s, RoutedEventArgs e)
        {
            var addressToBeDeleted = (s as FrameworkElement).DataContext as AddressDTO;

            var dal = new AddressDAL(Mapper);
            dal.DeleteAddress(addressToBeDeleted);
            GetAddress();
        }

        private void UpdateAddressForEdit(object s, RoutedEventArgs e)
        {
            selectedAddress = (s as FrameworkElement).DataContext as AddressDTO;
            UpdateAddressGrid.DataContext = selectedAddress;
        }

        private void UpdateAddress(object s, RoutedEventArgs e)
        {
            var dal = new AddressDAL(Mapper);
            dal.EditAddress(selectedAddress);
            GetAddress();
        }
    }
}

