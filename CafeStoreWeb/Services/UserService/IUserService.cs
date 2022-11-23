using CafeStoreManagement.Models;
using System.Reflection;

namespace CafeStoreWeb.Services.UserService
{
    public interface IUserService
    {
        Task<RegisterModel> AddUser(RegisterModel registerModel);
        Task<LoginModel> LoginUser(LoginModel LoginModel);
        Task<List<ItemDetailModel>> GetItemDetails();
    }
}
