using System;
using System.Collections.Generic;
using System.Text;

namespace RosabellaCosmetics.Business.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        //public Category Category { get; set; }
        //public Supplier Supplier { get; set; }
        //public ICollection<Customer> Customers { get; set; }
    }
}
