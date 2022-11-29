using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"|{Id,-3}|{Name,-12}|{Phone,-18}|{AddressId,-5}|";
        }
    }
}
