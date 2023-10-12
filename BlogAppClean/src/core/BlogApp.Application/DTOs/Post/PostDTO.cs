using System;
using System.Collections.Generic;
using BLOGAPP.Application.DTOs.Comment;
using BLOGAPP.Application.DTOs.Common;

namespace BLOGAPP.Application.DTOs.Post;

public class PostDTO : BaseDto, IPostDTO
{
    public string? Title { get; set; }
    public string? Content { get; set; } 
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public List<CommentDTO> Comments {get;}
}