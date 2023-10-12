using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Post;

public class PostCreateDTO : IPostDTO
{
    public string Title { get; set; }
    public string Content { get; set; } 
    public string CreatedBy { get; set; }

}