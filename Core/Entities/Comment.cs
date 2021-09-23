using Core.Entities.Base_Entities;
using System;

namespace Core.Entities
{
    public class Comment : Title_Content
    {
        public Guid CommentID { get; set; }
        public Guid CompanyID { get; set; }

        public Company Company { get; set; } //nav prop
    }
}
