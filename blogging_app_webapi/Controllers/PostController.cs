using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blogging_app_webapi.Data;
using blogging_app_webapi.Models;

namespace blogging_app_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly BloggingContext _context;

        public PostController(BloggingContext context)
        {
            _context = context;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _context.Posts.ToList();
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public IActionResult GetPostById(int postId)
        {
            var post = _context.Posts.Find(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPostById), new { postId = post.Id }, post);
        }

        [HttpPut("{postId}")]
        public IActionResult UpdatePost(int postId, Post updatedPost)
        {
            var post = _context.Posts.Find(postId);
            if (post == null)
            {
                return NotFound();
            }

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            _context.Posts.Update(post);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int postId)
        {
            var post = _context.Posts.Find(postId);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return NoContent();
        }
    }
}