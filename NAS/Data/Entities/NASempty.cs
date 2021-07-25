using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NAS.Data.Entities
{
    public class NAS_Empty
    {
        public NAS_Empty()
        {
            this.Price = new HashSet<Price>();
        }
        public int Id { get; set; }
        public string Manufacturer { get; set; }   
        public string SKU { get; set; }
        [StringLength(600)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(7, 2)")]
        public decimal Cost { get; set; }
        public ICollection<Price> Price { get; set; }
    }
}
