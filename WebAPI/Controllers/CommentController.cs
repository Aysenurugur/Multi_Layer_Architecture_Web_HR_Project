using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        public CommentController(ICommentService _commentService, IMapper _mapper)
        {
            this.commentService = _commentService;
            this.mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments() //test edildi
        {
            var comments = await commentService.GetAllComments();
            var commentDTO = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments);
            return Ok(commentDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentByCompanyId(Guid id) //test edildi
        {
            var comment = commentService.GetCommentByCompanyId(id);
            var commentDTO = mapper.Map<Comment, CommentDTO>(comment);
            return Ok(commentDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentDTO commentDTO) //test edildi
        {
            var commentToCreate = mapper.Map<CommentDTO, Comment>(commentDTO);
            var newComment = await commentService.CreateComment(commentToCreate);
            var comment = await commentService.GetCommentById(newComment.CommentID);
            var commentResource = mapper.Map<Comment, CommentDTO>(comment);
            return Ok(commentResource);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CommentDTO commentDTO) //test edildi
        {
            try
            {
                Comment comment = mapper.Map<CommentDTO, Comment>(commentDTO);
                await commentService.UpdateComment(comment);
                return Ok(mapper.Map<Comment, CommentDTO>(comment));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
