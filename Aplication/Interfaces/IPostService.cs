﻿using Aplication.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces;

public interface IPostService
{
    IEnumerable<PostDto> GetAllPost();
    PostDto GetPostById(int id);

    PostDto AddNewPost(CreatePostDto newPost);
    void UpdatePost(UpdatePostDto updatePost);
    void DeletePost(int id);
}