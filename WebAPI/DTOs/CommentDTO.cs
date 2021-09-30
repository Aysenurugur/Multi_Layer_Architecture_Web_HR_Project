using Core.Entities;
using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CommentDTO
    {
        //anasayfa
        public Guid CommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CompanyId { get; set; }//Yorum detay için şirkt bilgileri
    }
}
