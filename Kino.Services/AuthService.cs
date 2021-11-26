using System; 
// using Microsoft.EntityFrameworkCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Kino.Services.ViewModel;
using System.Security.Claims;

namespace Kino.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpContext _httpContext;

        public AuthService(IHttpContextAccessor httpContext)
        {
            this._httpContext = httpContext.HttpContext;
        }
        public async Task<bool> AuthenticateAsync(ConnectViewModel model)
        {
            if(model.Login == "Ich" && model.Password == "password")
            {
                List<Claim> claims = new List<Claim>()
                {

                };
                ClaimsPrincipal principal = new ClaimsPrincipal();

                await this._httpContext.SignInAsync("Cookies", principal);

                return true;
            }
            return false;
        }

        public Task<bool> IsAuthenticated()
        {
            throw new NotImplementedException();
        }

        public async Task LogOutAsync()
        {
            await _httpContext.SignOutAsync();
            throw new NotImplementedException();
        }

    }
}