using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAS.Data.Entities
{
    public class HardDrive
    {
        public HardDrive() {
            this.PriceHardDrives = new HashSet<PriceHardDrive>();
        }
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        //public string Model { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Cost { get; set; }

        public ICollection<PriceHardDrive> PriceHardDrives { get; set; }
    }
}
