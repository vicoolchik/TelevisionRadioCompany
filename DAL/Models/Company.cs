using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Company
    {
        public Company()
        {
            RadioStations = new HashSet<RadioStation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<RadioStation> RadioStations { get; set; }
    }
}
