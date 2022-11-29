using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelevisionRadioCompany.Command
{
    internal class Address
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(AddressDAL).Assembly)
                );


            return config.CreateMapper();
        }

        internal void CreateAddressCommand(int flat, int house, int streetId)
        {
            var dal = new AddressDAL(Mapper);

            var address = new AddressDTO
            {
                Flat = flat,
                House = house,
                StreetId = streetId
            };
            address = dal.CreateAddress(address);
            Console.WriteLine($"New address ID : {address.Id}");
        }


        internal void PrintAllAddressesCommand()
        {
            var dal = new AddressDAL(Mapper);

            var addressList = dal.GetAllAddresses();

            Console.WriteLine($"\n|{"ID",-3}|{"Flat",-5}|{"House",-5}|{"StreetId",-5}|\n");
            foreach (var address in addressList)
            {
                Console.WriteLine(address.ToString());
            }
        }

        internal void EditAddressCommand(int Id ,int flat, int house, int streetId)
        {
            var dal = new AddressDAL(Mapper);

            var address = new AddressDTO
            {
                Flat = flat,
                House = house,
                StreetId = streetId
            };
            address = dal.EditAddressByID(address, Id);
            Console.WriteLine($"Edited address ID : {(address != null ? $"{ address.Id}" : "null")}");
        }

        internal void DeleteAddressCommand(int Id)
        {
            var dal = new AddressDAL(Mapper);
            var address = dal.DeleteAddressByID(Id);

            Console.WriteLine($"Edited address ID : {(address != null ? $"{address.Id}" : "null")}");
        }
    }
}


