namespace CafeStoreManagement.Model
{
    public class LoginResult
    {
        public bool Successful { get; set; } = true;
        public string? Error { get; set; }
        public string? Token { get; set; }
    }
}
