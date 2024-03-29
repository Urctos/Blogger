﻿using Application.Dto;
using Application.Dto.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICosmosPostService
    {
        Task<IEnumerable<CosmosPostDto>> GetAllPostAsync();
        Task<CosmosPostDto> GetPostByIdAsync(string id);

        Task<CosmosPostDto> AddNewPostAsync(CreateCosmosPostDto newPost);
        Task UpdatePostAsync(UpdateCosmosPostDto updatePost);
        Task DeletePostAsync(string id);
    }
}
