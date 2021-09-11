using Data.Entities.Base_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Comment : Title_Content
    {
        public int CommentID { get; set; }
        public int CompanyID { get; set; }

        public Company Company { get; set; } //nav prop
    }
}
