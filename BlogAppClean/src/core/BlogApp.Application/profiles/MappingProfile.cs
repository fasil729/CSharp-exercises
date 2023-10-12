using AutoMapper;
using BLOGAPP.Application.DTOs;
using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.DTOs.Comment;
using BLOGAPP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateMap<Post, PostDTO>().ReverseMap();
         CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.Select(comment => new CommentDTO
                {
                    Id = comment.Id,
                    Text = comment.Text,
                })))
                .ReverseMap();
        CreateMap<Post, PostCreateDTO>().ReverseMap();
        CreateMap<Post, PostUpdateDTO>().ReverseMap();

        CreateMap<Comment, CommentDTO>()
            .ForMember(dest => dest.Postid, opt => opt.MapFrom(src => src.Postid))
            .ReverseMap();        
        CreateMap<Comment, CommentCreateDTO>().ReverseMap();
        CreateMap<Comment, CommentUpdateDTO>().ReverseMap();
    }
}