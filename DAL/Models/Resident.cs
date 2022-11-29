using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Resident
    {
        public Resident()
        {
            Residences = new HashSet<Residence>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Residence> Residences { get; set; }
    }
}
