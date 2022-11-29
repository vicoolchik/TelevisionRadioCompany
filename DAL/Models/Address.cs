using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Address
    {
        public Address()
        {
            Companies = new HashSet<Company>();
            Residences = new HashSet<Residence>();
        }

        public int Id { get; set; }
        public int? Flat { get; set; }
        public int House { get; set; }
        public int StreetId { get; set; }

        public virtual Street Street { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Residence> Residences { get; set; }
    }
}
