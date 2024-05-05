using Application.Dto;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    public class PostServiceTests
    {
        [Fact]
        public async Task AddPostAsyncShouldInvokeAddAsyncOnPostRepository()
        {
            //Arrange
            var postRepositoryMock = new Mock<IPostRepository>();
            var mappereMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<PostService>>();


            var postService = new PostService(postRepositoryMock.Object, mappereMock.Object, loggerMock.Object);

            var postDto = new CreatePostDto()
            {
                Title = "Test",
                Content = "1",
            };

            mappereMock.Setup(x=>x.Map<Post>(postDto)).Returns(new Post() { Title = postDto.Title, Content = postDto.Content });


            //Act
            await postService.AddNewPostAsync(postDto, "100dbe8c-699b-4557-8b8d-f6f829067f81");

            //Assert
            postRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Post>()), Times.Once);
        }

        [Fact]
        public async Task WhenInvokeGetPostAsyncItShouldInvokeGetAsyncOnPostRepository()
        {
            //Arrange
            var postRepositoryMock = new Mock<IPostRepository>();
            var mappereMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<PostService>>();


            var postService = new PostService(postRepositoryMock.Object, mappereMock.Object, loggerMock.Object);

            var post = new Post(1, "Title 1", "Content 1");
            var postDto = new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };

            mappereMock.Setup(x => x.Map<Post>(postDto)).Returns(post);
            postRepositoryMock.Setup(x => x.GetByIdAsync(post.Id)).ReturnsAsync(post);


            //Act

            var existingPostDto = await postService.GetPostByIdAsync(post.Id);

            //Assert

            postRepositoryMock.Verify(x => x.GetByIdAsync(post.Id), Times.Once);
            postDto.Should().NotBeNull();
            postDto.Title.Should().NotBeNull();
            postDto.Content.Should().BeEquivalentTo(post.Content);
            postDto.Content.Should().BeEquivalentTo(post.Content);
        }
    }
}
