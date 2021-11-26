using System; 
using System.Threading.Tasks;
using Kino.Services.ViewModel;

namespace Kino.Services
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticated();
        Task<bool> AuthenticateAsync(ConnectViewModel model);

        Task LogOutAsync(); 
    }
}