using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto;

public class PostDto : IMap
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Post, PostDto>()
         .ForMember(dto => dto.Title, opt => opt.MapFrom(src => src.Title ?? string.Empty)) // Zabezpieczenie dla Title
         .ForMember(dto => dto.Content, opt => opt.MapFrom(src => src.Content ?? string.Empty)); // Zabezpieczenie dla Content
    }
}

