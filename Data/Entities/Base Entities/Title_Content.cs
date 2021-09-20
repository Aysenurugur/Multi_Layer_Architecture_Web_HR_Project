using System;

namespace Data.Entities.Base_Entities
{
    public abstract class Title_Content
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
