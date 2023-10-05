using System;
using System.Collections.Generic;

namespace blogging_app_webapi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Comment> Comments { get; set; }
    }
}