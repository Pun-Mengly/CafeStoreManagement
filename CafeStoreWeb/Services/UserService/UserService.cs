using Blazored.SessionStorage;
using CafeStoreManagement.Models;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace CafeStoreWeb.Services.UserService
{
    class TokenModel
    {
        public string? token { get; set; }
    }
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<RegisterModel> AddUser(RegisterModel registerModel)
        {
            await  httpClient.PostAsJsonAsync("api/Authenticate/register-admin", registerModel);
            return registerModel;
        }

        public async Task<List<ItemDetailModel>> GetItemDetails()
        {
            var result=await httpClient.GetFromJsonAsync<List<ItemDetailModel>>("api/ItemDetail");
            return result!;
        }

        public async Task<LoginModel> LoginUser(LoginModel LoginModel)
        {
            var result=await httpClient.PostAsJsonAsync("api/Authenticate/login", LoginModel);
            var obj = result.Content.ReadAsStringAsync().Result;
            var token = System.Text.Json.JsonSerializer.Deserialize<TokenModel>(obj);
            //sessionStorage.SetItemAsync("Token", token);
            return LoginModel;
        }
    }
}
