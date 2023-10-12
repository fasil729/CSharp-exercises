using System;
using System.Collections.Generic;

namespace BLOGAPP.Application.DTOs.Post;

public interface IPostDTO {
    public string? Title { get; set; }
    public string? Content { get; set; } 
}