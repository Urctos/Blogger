using Application.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAPI;
using WebAPI.Wrappers;
using WebAPI.Helpers;
using Xunit;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace EndToEndTests.Controllers
{
    public class PostControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public PostControllerTests()
        {
            // Arrage
            var projectDir = Helper.GetProjectPath("", typeof(Program).GetTypeInfo().Assembly);
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                .UseStartup<Program>());
            _client = _server.CreateClient();
        }

        //[Fact]
        //public async Task FetchingPostShouldReturnNotEmptyCollection()
        //{
        //    _client.DefaultRequestHeaders.Authorization =
        //    new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMGRiZThjLTY5OWItNDU1Ny04YjhkLWY2ZjgyOTA2N2Y4MSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJOSU5JT09PTyIsImp0aSI6Ijc4YTE5OTcyLTgxZDItNGY0Mi1iMWUzLTM1YWIxN2M0Yjc3ZiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE3MTQzNDIzOTl9.92pwqarQ-WmghfnU_NdEtHbXEdDSDUHQdFnEj-SeSbA");
        //    // Act
        //    var response = await _client.GetAsync(@"api/posts/Get");
        //    var content = await response.Content.ReadAsStringAsync();
        //    var pagedResponse = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<PostDto>>>(content);

        //    // Assert

        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //    pagedResponse?.Data.Should().NotBeEmpty();


        //}
    }
}
