using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Street
    {
        public Street()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
