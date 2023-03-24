
using CafeStoreManagement.Models;
using System.Globalization;
using static System.Net.WebRequestMethods;

using System.Net.Http.Headers;

using System.Text.Json;
using CafeStoreManagement.DTOs;

namespace CafeStoreWeb.Pages.Dashboard;

public partial class Dashboard
{
    public List<RevenueOutletsDto> ListOutlets { get; set; } = new List<RevenueOutletsDto>();
    public List<CategoryModel> CategoryModels { get; set; } = new List<CategoryModel>();
    public List<PopularItemDto> PopularItems { get; set; } = new List<PopularItemDto>();
    public List<RevenueOutletByYear> RevenueOutletByYears { get; set; } = new List<RevenueOutletByYear>();

    public Dashboard()
    {
  
    }
    public async Task GetRevenueOutlets()
    {
        string token = await sessionStorage.GetItemAsync<string>("Token");
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/SaleItems/revenue-outlet");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var respone = await Http.SendAsync(request);
        var body = respone.Content.ReadAsStringAsync();
        string result = body.Result;
        ListOutlets = JsonSerializer.Deserialize<List<RevenueOutletsDto>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
    public async Task GetRevenueOutletByYears()
    {
        string token = await sessionStorage.GetItemAsync<string>("Token");
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/SaleItems/revenue-outlet-by-year");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var respone = await Http.SendAsync(request);
        var body = respone.Content.ReadAsStringAsync();
        string result = body.Result;
        RevenueOutletByYears = JsonSerializer.Deserialize<List<RevenueOutletByYear>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
    public async Task GetCategories()
    {
        string token = await sessionStorage.GetItemAsync<string>("Token");
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/Categories");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var respone = await Http.SendAsync(request);
        var body = respone.Content.ReadAsStringAsync();
        string result = body.Result;
        CategoryModels = JsonSerializer.Deserialize<List<CategoryModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
    public async Task GetItemPopulars()
    {
        string token = await sessionStorage.GetItemAsync<string>("Token");
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/SaleItems/items-pupular");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var respone = await Http.SendAsync(request);
        var body = respone.Content.ReadAsStringAsync();
        string result = body.Result;
        PopularItems = JsonSerializer.Deserialize<List<PopularItemDto>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}
