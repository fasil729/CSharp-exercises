using System;
using System.Collections.Generic;
using BLOGAPP.Application.DTOs.Common;

namespace BLOGAPP.Application.DTOs.Comment;

public class CommentDTO: BaseDto,ICommentDTO
{
    public int? Postid {get; set;}
    public string? Text { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
}