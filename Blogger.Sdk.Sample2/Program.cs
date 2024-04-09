using System;
using Blogger.Contracts.Request;
using BloggerSdk;
using Refit;

namespace Blogger.Sdk.Sample2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var identityApi = RestService.For<IIdentityApi>("https://localhost:44338/");

            var register = await identityApi.RegisterAsync(new RegisterModel()
            {
                Email = "sdkaccount@gmail.com",
                Username = "sdkaccount",
                Password = "Pa$$wOrd123!"
            });

            var login = await identityApi.LoginAsync(new LoginModel()
            {
                Username = "sdkaccount",
                Password = "Pa$$wOrd123!"
            });
        }
    }
}
