using System;
using System.Collections.Generic;
using System.Text;

namespace RosabellaCosmetics.Business.DTOs
{
    public class CustomerDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
