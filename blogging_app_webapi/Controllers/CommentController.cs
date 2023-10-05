using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blogging_app_webapi.Data;
using blogging_app_webapi.Models;

namespace blogging_app_webapi.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly BloggingContext _context;

        public CommentController(BloggingContext context)
        {
            _context = context;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = _context.Comments.ToList();
            return Ok(comments);
        }

        [HttpGet("{commentId}")]
        public IActionResult GetCommentById(int commentId)
        {
            var comment = _context.Comments.Find(commentId);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCommentById), new { commentId = comment.CommentId }, comment);
        }

        [HttpPut("{commentId}")]
        public IActionResult UpdateComment(int commentId, Comment updatedComment)
        {
            var comment = _context.Comments.Find(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            comment.Content = updatedComment.Content;
            _context.Comments.Update(comment);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            var comment = _context.Comments.Find(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return NoContent();
        }
    }
}