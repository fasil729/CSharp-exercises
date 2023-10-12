using System;
using System.Collections.Generic;
using BLOGAPP.Application.DTOs.Common;

namespace BLOGAPP.Application.DTOs.Post;

public class PostUpdateDTO :BaseDto,IPostDTO
{
    public int Id {get; set;}
    public string? Title { get; set; }
    public string? Content { get; set; } 
    public string? UpdatedBy { get; set; }
}