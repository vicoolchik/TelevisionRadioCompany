using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Concrete
{
    public class AddressDAL : IAddress
    {
        private readonly IMapper _mapper;
        public AddressDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AddressDTO CreateAddress(AddressDTO address)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var addressInDB = _mapper.Map<Address>(address);
                entites.Addresses.Add(addressInDB);
                entites.SaveChanges();
                return _mapper.Map<AddressDTO>(addressInDB);
            }
        }

        public List<AddressDTO> GetAllAddresses()
        {
            using (var entities = new TelevisionRadioCompanyContext())
            {
                var addresses = entities.Addresses.ToList();
                return _mapper.Map<List<AddressDTO>>(addresses);
            }
        }


        public AddressDTO DeleteAddressByID(int id)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var addressInDB = entites.Addresses.SingleOrDefault(x => x.Id == id);
                if (addressInDB != null)
                {
                    entites.Addresses.Remove(addressInDB);
                    entites.SaveChanges();
                    return _mapper.Map<AddressDTO>(addressInDB);
                }
                return null;
            }
        }

        public AddressDTO EditAddressByID(AddressDTO address, int id)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var addressInDB = _mapper.Map<Address>(address);
                addressInDB = entites.Addresses.SingleOrDefault(x => x.Id == id);
                if (addressInDB != null)
                {
                    addressInDB.Flat = address.Flat;
                    addressInDB.House = address.House;
                    addressInDB.StreetId = address.StreetId;
                    entites.SaveChanges();
                    return _mapper.Map<AddressDTO>(addressInDB);
                }
                return null;
            }
        }

        public AddressDTO DeleteAddress(AddressDTO address)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var addressInDB = _mapper.Map<Address>(address);
                addressInDB = entites.Addresses.SingleOrDefault(x => x.Id == address.Id);
                if (addressInDB != null)
                {
                    entites.Addresses.Remove(addressInDB);
                    entites.SaveChanges();
                    return _mapper.Map<AddressDTO>(addressInDB);
                }
                return null;
            }
        }

        public AddressDTO EditAddress(AddressDTO address)
        {
            using (var entites = new TelevisionRadioCompanyContext())
            {
                var addressInDB = _mapper.Map<Address>(address);
                addressInDB = entites.Addresses.SingleOrDefault(x => x.Id == address.Id);
                if (addressInDB != null)
                {
                    addressInDB.Flat = address.Flat;
                    addressInDB.House = address.House;
                    addressInDB.StreetId = address.StreetId;
                    entites.SaveChanges();
                    return _mapper.Map<AddressDTO>(addressInDB);
                }
                return null;
            }
        }

    }
}


