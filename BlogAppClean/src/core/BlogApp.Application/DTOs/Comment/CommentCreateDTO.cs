using System;
using System.Collections.Generic;
using BLOGAPP.Application.DTOs.Common;

namespace BLOGAPP.Application.DTOs.Comment;

public class CommentCreateDTO : ICommentDTO
{
    public int? Postid {get; set;}
    public string? Text { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}