using Blogger.Contracts.Request;
using Blogger.Contracts.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggerSdk
{
    public interface IIdentityApi
    {
        [Post("/api/identity/register")]
        Task<ApiResponse<Response>> RegisterAsync([Body] RegisterModel register);

        [Post("/api/identity/registerAdmin")]
        Task<ApiResponse<Response>> RegisterAdminAsync([Body] RegisterModel register);

        [Post("/api/identity/login")]
        Task<ApiResponse<AuthSuccessResponse>> LoginAsync([Body] LoginModel login);
    }
}
