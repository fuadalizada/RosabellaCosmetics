using System.Collections.Generic;

namespace RosabellaCosmetics.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        //public Category Category { get; set; }
        //public Supplier Supplier { get; set; }
        //public ICollection<Customer> Customers { get; set; }
    }
}