using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class RadioStation
    {
        public RadioStation()
        {
            Districts = new HashSet<District>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
