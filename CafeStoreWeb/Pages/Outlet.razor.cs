using Blazored.LocalStorage;
using CafeStoreManagement.Models;
using Radzen;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CafeStoreWeb.Pages;

public partial class Outlet
{
    IEnumerable<OutletModel> outlets;  
    public  Outlet()
    {
    
    }
    public async Task GetOutletsAsync(HttpClient http, ILocalStorageService sessionStorage) {
        string token = await sessionStorage.GetItemAsync<string>("Token");
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/Outlets");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var respone = await http.SendAsync(request);
        var body = respone.Content.ReadAsStringAsync();
        string result = body.Result;
        outlets = JsonSerializer.Deserialize<List<OutletModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
    public async Task OnSave(OutletModel model)
    {
        string token = await sessionStorage.GetItemAsync<string>("Token");
        Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await Http.PostAsJsonAsync("api/Outlets", model);
        //show success alert 
    }
}
