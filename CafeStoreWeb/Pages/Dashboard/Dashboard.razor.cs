
using CafeStoreManagement.Models;
using System.Globalization;
using static System.Net.WebRequestMethods;

using System.Net.Http.Headers;

using System.Text.Json;
using CafeStoreManagement.DTOs;

namespace CafeStoreWeb.Pages.Dashboard;

public partial class Dashboard
{
    public string Name { get; set; } = "Mengly";
    public List<RevenueOutletsDto> ListOutlets { get; set; } = new List<RevenueOutletsDto>();
    public List<string> ListItemPopulars { get; set; }= new List<string>() {"Food","Baverage","Set Item", "Souvenir" };

    public Dashboard()
    {
  
    }
    public async Task RevenueOutlets()
    {
        string token = await sessionStorage.GetItemAsync<string>("Token");
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/SaleItems/revenue-outlet");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var respone = await Http.SendAsync(request);
        var body = respone.Content.ReadAsStringAsync();
        string result = body.Result;
        ListOutlets = JsonSerializer.Deserialize<List<RevenueOutletsDto>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}
