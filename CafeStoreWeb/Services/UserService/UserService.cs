namespace CafeStoreWeb.Services.UserService
{
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
    }
}
