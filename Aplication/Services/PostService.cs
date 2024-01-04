using Aplication.Dto;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public PostDto AddNewPost(CreatePostDto newPost)
    {
        if (string.IsNullOrEmpty(newPost.Title))
        {
            throw new Exception("Post can not have an empty title.");
        }
            var post = _mapper.Map<Post>(newPost);
            _postRepository.Add(post);
            return _mapper.Map<PostDto>(post);
        
    }

    public void DeletePost(int id)
    {
        var post = _postRepository.GetById(id);
        _postRepository.Delete(post);
    }

    public IEnumerable<PostDto> GetAllPost()
    {
        var posts = _postRepository.GetAll();
        return _mapper.Map<IEnumerable<PostDto>>(posts);
    }

    public PostDto GetPostById(int id)
    {
        var post = _postRepository.GetById(id);
        return _mapper.Map<PostDto>(post);

    }

    public void UpdatePost(UpdatePostDto updatePost)
    {
        var existingPost = _postRepository.GetById(updatePost.Id);
        var post = _mapper.Map(updatePost, existingPost);
        _postRepository.Update(post);
    }

}

