using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CommentService:ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Comment> CreateComment(Comment newComment)
        {
            await unitOfWork.Comment.AddAsync(newComment);
            return newComment;
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await unitOfWork.Comment.GetAllAsync();
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            return await unitOfWork.Comment.GetByIDAsync(id);
        }

        public async Task UpdateComment(Comment comment)
        {
            unitOfWork.Comment.Update(comment);
            await unitOfWork.CommitAsync();
        }
    }
}
