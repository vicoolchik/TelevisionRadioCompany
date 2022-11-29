using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IAddress
    {
        List<AddressDTO> GetAllAddresses();
        AddressDTO CreateAddress(AddressDTO address);
        AddressDTO DeleteAddressByID(int id);
        AddressDTO EditAddressByID(AddressDTO address, int id);

    }
}
