using System;
using System.Linq;
using BloggingApp.Data;
using BloggingApp.Models;
using BloggingApp.Managers;

namespace BloggingApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                var postManager = new PostManager(context);
                var commentManager = new CommentManager(context);
                 

                // Perform CRUD operations and display blog posts and comments

                // Create a new post
                var post = new Post
                {
                    Title = "Sample Post",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    CreatedAt = DateTime.Now
                };
                postManager.CreatePost(post);
                Console.WriteLine("New post created successfully.");

                // Get the post by its ID
                var retrievedPost = postManager.GetPostById(post.PostId);
                if (retrievedPost != null)
                {
                    Console.WriteLine("Retrieved post:");
                    Console.WriteLine($"Post ID: {retrievedPost.PostId}");
                    Console.WriteLine($"Title: {retrievedPost.Title}");
                    Console.WriteLine($"Content: {retrievedPost.Content}");
                    Console.WriteLine($"Created At: {retrievedPost.CreatedAt}");
                }
                int post_id = retrievedPost.PostId;
                // Update the post
                if(retrievedPost != null)
                {
                    retrievedPost.Title = "Updated Post Title";
                    postManager.UpdatePost(retrievedPost);
                    Console.WriteLine("Post updated successfully.");
                }

                // Delete the post
                // if (retrievedPost != null)
                // {
                //     postManager.DeletePost(retrievedPost.PostId);
                //     Console.WriteLine("Post deleted successfully.");
                // }

                // Create a new comment
                var comment = new Comment
                {
                    PostId = post_id, // Assuming there is a post with ID 1
                    Text = "Great post!",
                    CreatedAt = DateTime.Now
                };
                commentManager.CreateComment(comment);
                Console.WriteLine("New comment created successfully.");

                // Get the comment by its ID
                var retrievedComment = commentManager.GetCommentById(comment.CommentId);
                if (retrievedComment != null)
                {
                    Console.WriteLine("Retrieved comment:");
                    Console.WriteLine($"Comment ID: {retrievedComment.CommentId}");
                    Console.WriteLine($"Post ID: {retrievedComment.PostId}");
                    Console.WriteLine($"Text: {retrievedComment.Text}");
                    Console.WriteLine($"Created At: {retrievedComment.CreatedAt}");
                }

                // Update the comment
                if (retrievedComment != null)
                {
                    retrievedComment.Text = "Updated comment text";
                    commentManager.UpdateComment(retrievedComment);
                    Console.WriteLine("Comment updated successfully.");
                }

                // Delete the comment
                if (retrievedComment != null)
                {
                    commentManager.DeleteComment(retrievedComment.CommentId);
                    Console.WriteLine("Comment deleted successfully.");
                }
            }
        }
    }
}
