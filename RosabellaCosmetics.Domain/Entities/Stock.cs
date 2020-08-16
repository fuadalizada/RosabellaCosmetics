using System.Collections.Generic;

namespace RosabellaCosmetics.Domain.Entities
{
    public class Stock:BaseEntity
    {
        public int Quantity { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}