using Application.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPictureService
    {
        Task<PictureDto> AddPictureToPostAsync(int postId, IFormFile file);
        Task<IEnumerable<PictureDto>> GetPicturesByPostIdAsync(int postId);
        Task<PictureDto> GetPictureByIdAsync(int id);

        Task SetMainPicture(int postId, int id); 
        Task DeletePictureAsync(int id);
    }
}
