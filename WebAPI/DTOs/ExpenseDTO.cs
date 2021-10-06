using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class ExpenseDTO
    {
        public Guid ExpenseId { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool? IsApproved { get; set; }
    }
}
