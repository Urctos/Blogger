using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BloggerContext _context;

    public PostRepository(BloggerContext context)
    {
        _context = context;
    }



    public IEnumerable<Post> GetAll()
    {
        //return _context.Posts;

        return _context.Posts
        .Select(post => new Post
        {
            Id = post.Id,
            Title = post.Title ?? string.Empty, 
            Content = post.Content ?? string.Empty
            
        }).ToList();

    }

    public Post GetById(int id)
    {
        //return _context.Posts.SingleOrDefault(x => x.Id == id);

        var post = _context.Posts
        .Where(x => x.Id == id)
        .Select(p => new {
            p.Id,
            Title = p.Title ?? string.Empty, 
            Content = p.Content ?? string.Empty,
        })
        .SingleOrDefault();

        if (post == null)
            return null;

        return new Post
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content
        };
    }

    public Post Add(Post post)
    {
        post.Created = DateTime.UtcNow;
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post;

    }

    public void Update(Post post)
    {
        post.LastModified = DateTime.UtcNow;
        _context.Posts.Update(post);
        _context.SaveChanges();

    }
    public void Delete(Post post)
    {
        _context.Posts.Remove(post);
        _context.SaveChanges();
    } 
}

