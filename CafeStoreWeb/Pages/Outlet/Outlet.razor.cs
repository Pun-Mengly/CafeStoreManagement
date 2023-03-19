using Blazored.LocalStorage;
using CafeStoreManagement.Models;
using Radzen;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CafeStoreWeb.Pages.Outlet;

public partial class Outlet
{
    public static ICollection<OutletModel> outlets { get; set; }
    public Outlet()
    {
        
    }
    public async Task GetOutletsAsync() {
        string token = await sessionStorage.GetItemAsync<string>("Token");
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/Outlets");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var respone = await Http.SendAsync(request);
        var body = respone.Content.ReadAsStringAsync();
        string result = body.Result;
        outlets = JsonSerializer.Deserialize<List<OutletModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}
