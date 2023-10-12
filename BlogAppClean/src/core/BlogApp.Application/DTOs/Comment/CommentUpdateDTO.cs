using System;
using System.Collections.Generic;
using BLOGAPP.Application.DTOs.Common;

namespace BLOGAPP.Application.DTOs.Comment;

public class CommentUpdateDTO : BaseDto, ICommentDTO
{
    public int Id {get; set;}
    public int? Postid { get; set; }
    public string? Text { get; set; }
    public string? UpdatedBy { get; set; }
}