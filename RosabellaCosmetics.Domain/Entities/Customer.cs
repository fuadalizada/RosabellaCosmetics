namespace RosabellaCosmetics.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        //public Gender Gender { get; set; }
    }
}