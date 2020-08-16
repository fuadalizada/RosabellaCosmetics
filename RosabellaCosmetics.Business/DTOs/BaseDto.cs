using System;
using System.Collections.Generic;
using System.Text;

namespace RosabellaCosmetics.Business.DTOs
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
