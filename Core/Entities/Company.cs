using Core.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Company
    {
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public short AllowedVacationDays { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsMonthly { get; set; }
        public bool IsActive { get; set; }
        public byte[] Logo { get; set; }

        public Comment Comment { get; set; } //nav prop
        public ICollection<User> Users { get; set; }
    }
}
