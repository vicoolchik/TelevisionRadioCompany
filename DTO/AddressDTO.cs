using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int? Flat { get; set; }
        public int House { get; set; }
        public int StreetId { get; set; }

        public override string ToString()
        {
            return $"|{Id,-3}|{Flat,-5}|{House,-5}|{StreetId,-5}|";
        }

    }
}
