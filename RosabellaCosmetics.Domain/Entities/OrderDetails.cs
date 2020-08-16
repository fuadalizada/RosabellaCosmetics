namespace RosabellaCosmetics.Domain.Entities
{
    public class OrderDetails:BaseEntity
    {
        //public int OrderId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public Product Product { get; set; }
    }
}