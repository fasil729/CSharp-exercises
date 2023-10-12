using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Comment;

public interface ICommentDTO
{
    public int? Postid {get; set;}
    public string? Text { get; set; }
}