using Data.Entities.Base_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Debit : Title_Content
    {
        public int DebitID { get; set; }
        public Guid UserID { get; set; }
        public int? VetoMessageID { get; set; }
        public bool IsApproved { get; set; }

        public VetoMessage VetoMessage { get; set; } //nav prop
        //user nav prop gelecek
    }
}
