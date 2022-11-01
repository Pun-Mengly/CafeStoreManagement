using System.Reflection;

namespace CafeStoreWeb.Services.UserService
{
    public interface IUserService
    {
        Task<RegisterModel> AddUser(RegisterModel registerModel);
    }
}
