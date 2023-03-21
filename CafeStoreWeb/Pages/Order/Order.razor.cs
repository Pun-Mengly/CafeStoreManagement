using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using CafeStoreWeb.Data;
using CafeStoreWeb.Pages.Outlet;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;


namespace CafeStoreWeb.Pages.Order
{
    public partial class Order
    {
        public IEnumerable<ItemResponse> items { get; set; }
        public List<ItemResponse> itemTemp { get; set; }

        public Order()
        {
        }
        public async Task GetItemDetailsAsync()
        {
            string token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Items");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            items = JsonSerializer.Deserialize<List<ItemResponse>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
