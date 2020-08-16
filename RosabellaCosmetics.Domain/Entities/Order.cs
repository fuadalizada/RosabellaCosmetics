using System;

namespace RosabellaCosmetics.Domain.Entities
{
    public class Order:BaseEntity
    {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public Customer Customer { get; set; }
    }
}