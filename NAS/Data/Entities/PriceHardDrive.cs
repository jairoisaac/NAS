using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAS.Data.Entities
{
    public class PriceHardDrive
    {
        public int Id { get; set; }
        public int PriceId { get; set; }
        public int HardDriveId { get; set; }

        public virtual Price Price { get; set; }
        public virtual HardDrive HardDrive { get; set; }
    }
}
