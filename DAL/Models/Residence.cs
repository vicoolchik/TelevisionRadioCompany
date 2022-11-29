using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Residence
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int ResidentId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Resident Resident { get; set; }
    }
}
