using Core.Entities.Base_Entities;

namespace Core.Entities
{
    public class Comment : Title_Content
    {
        public int CommentID { get; set; }
        public int CompanyID { get; set; }

        public Company Company { get; set; } //nav prop
    }
}
