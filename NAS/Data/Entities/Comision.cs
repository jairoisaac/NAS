

using System.ComponentModel.DataAnnotations.Schema;

namespace NAS.Data.Entities
{
    public class Comision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Value { get; set; }
    }
}
