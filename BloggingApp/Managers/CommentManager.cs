using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BloggingApp.Data;
using BloggingApp.Models;

namespace BloggingApp.Managers
{
    public class CommentManager
    {
        private readonly BloggingContext _context;

        public CommentManager(BloggingContext context)
        {
            _context = context;
        }

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public Comment GetCommentById(int commentId)
        {
            return _context.Comments.Find(commentId);
        }

        public void UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public void DeleteComment(int commentId)
        {
            var comment = _context.Comments.Find(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }
    }
}