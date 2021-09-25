using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CommentDTO
    {
        //anasayfa
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FullName { get; set; } // Yorumu yazan kişinin adsoyadı  
    }
}
