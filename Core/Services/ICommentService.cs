using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllComments();
        Task<Comment> GetCommentById(Guid id);
        Task<Comment> CreateComment(Comment newComment);
        Task UpdateComment(Comment commentToBeUpdated, Comment comment);
        Task DeleteComment(Comment comment);
    }
}
