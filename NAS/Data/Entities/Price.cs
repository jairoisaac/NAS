using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAS.Data.Entities
{
    public class Price
    {
        public Price()
        {
            this.PriceHardDrives = new HashSet<PriceHardDrive>();
        }
        public int Id { get; set; }
        public string SKU { get; set; }
        public int NASId { get; set; }
        public virtual NAS_Empty NAS_Empty { get; set; }
        public ICollection<PriceHardDrive> PriceHardDrives { get; set; }
    }
}
