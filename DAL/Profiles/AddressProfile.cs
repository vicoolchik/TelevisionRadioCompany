using AutoMapper;
using DAL.Models;
using DTO;

namespace DAL.Profiles
{
    public class AddressProfile :Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
