
using CafeStoreManagement.Model;
using CafeStoreManagement.Models;

namespace AuthorizationClient.Service
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
