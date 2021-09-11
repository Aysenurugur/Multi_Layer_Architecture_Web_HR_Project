using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Company
    {
        public int CompanyID { get; set; }
        public int CommentID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public short AllowedVacationDays { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsMonthly { get; set; }
        public bool IsActive { get; set; }
        public byte[] Logo { get; set; }

        public Comment Comment { get; set; } //nav prop
        //icollection user gelecek
    }
}
