﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Data.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte[] Photo { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool? IsWoman { get; set; }
        public DateTime? HiredDate { get; set; }
        public string Title { get; set; } // Unvan
        public string Department { get; set; }
        public int? CompanyID { get; set; } //FK

        public Company Company { get; set; }
        public ICollection<Debit> Debits { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<DayOff> DayOffs { get; set; }
        public ICollection<Shift> Shifts { get; set; }
        public ICollection<Break> Breaks { get; set; }
        public ICollection<VetoMessage> VetoMessages { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Promotion> Promotions { get; set; }
    }
}
