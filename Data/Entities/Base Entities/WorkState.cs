using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Base_Entities
{
    public class WorkState //kadirden user ı aldıktan sonra nav prop ekle!!!!
    {
        public Guid UserID { get; set; } //FK
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
