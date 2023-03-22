using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using CafeStoreWeb.Data;
using CafeStoreWeb.Pages.Outlet;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Radzen;
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
        public IEnumerable<SizeModel> sizeModels { get; set; }
        public IEnumerable<ItemModel> itemModels { get; set; }
        public List<ItemResponse> itemTemp { get; set; }
        public static List<ReceiptModel> OrderModels { get; set; }=new List<ReceiptModel>();
        public string token { get; set; }

        public Order()
        {
        }
        public async Task GetItemDetailsAsync()
        {
            token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Items");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            items = JsonSerializer.Deserialize<List<ItemResponse>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        public async Task Sizes()
        {
            token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Sizes");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            sizeModels = JsonSerializer.Deserialize<List<SizeModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        public async Task Items()
        {
            token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Items");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            itemModels = JsonSerializer.Deserialize<List<ItemModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        public async Task Purchasing(List<ReceiptModel> model, NotificationMessage message)
        {
            var receiptId=Guid.NewGuid();
            model.ForEach(e=>e.ReceiptId=receiptId);
            string token = await sessionStorage.GetItemAsync<string>("Token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Http.PostAsJsonAsync("api/SaleItems", model);
            //show success alert 
            if ((int)response.StatusCode == 200)
            {
                NotificationService.Notify(message);
                //Navigation.NavigateTo("outlet");
                OrderModels.Clear();
            }
        }
    }
}
