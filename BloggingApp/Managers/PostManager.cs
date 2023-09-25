using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BloggingApp.Data;
using BloggingApp.Models;

namespace BloggingApp.Managers
{
    public class PostManager
    {
        private readonly BloggingContext _context;

        public PostManager(BloggingContext context)
        {
            _context = context;
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public Post GetPostById(int postId)
        {
            return _context.Posts
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.PostId == postId);
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var post = _context.Posts.Find(postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }
    }
}