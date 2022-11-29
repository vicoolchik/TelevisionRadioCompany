using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class District
    {
        public District()
        {
            Streets = new HashSet<Street>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? RadioStationId { get; set; }

        public virtual RadioStation RadioStation { get; set; }
        public virtual ICollection<Street> Streets { get; set; }
    }
}
