using Blazored.LocalStorage;
using CafeStoreManagement.Features.ItemDetail.Response;
using CafeStoreManagement.Models;
using CafeStoreWeb.Pages.Outlet;
using Microsoft.AspNetCore.Components;
using MoreLinq;
using Radzen;
using System.Net.Http.Headers;
using System.Text.Json;


namespace CafeStoreWeb.Pages.ItemDetail
{
    public partial class CreateForm
    {
        public int StatusCode { get; set; }
        public List<SizeModel> sizes { get; set; }
        public List<OutletModel> outlets { get; set; }
        public List<CategoryModel> categories { get; set; }
        List<ItemDetailModel> itemDetails = new List<ItemDetailModel> {};
        ItemModel model = new ItemModel();

        public CreateForm()
        {
        }
        public async Task OnSave(NotificationMessage message)
        {
            try
            {
                model.ItemDetails = itemDetails;
                string token = await sessionStorage.GetItemAsync<string>("Token");
                Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await Http.PostAsJsonAsync("api/ItemDetail", model);
                //show success alert 
                if ((int)response.StatusCode == 200)
                {
                    NotificationService.Notify(message);
                    Navigation.NavigateTo("item-detail");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task Sizes()
        {
            string token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Sizes");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            sizes = JsonSerializer.Deserialize<List<SizeModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        public async Task Outlets()
        {
            string token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Outlets");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            outlets = JsonSerializer.Deserialize<List<OutletModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        public async Task Categories()
        {
            string token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Categories");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            categories = JsonSerializer.Deserialize<List<CategoryModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
