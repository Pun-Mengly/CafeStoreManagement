using CafeStoreManagement.DTOs;
using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using CafeStoreWeb.Data;
using CafeStoreWeb.Pages.Outlet;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;


namespace CafeStoreWeb.Pages.Reports.Receipt
{
    public partial class ReceiptComponent
    {
        public List<ReceiptDto> ReceiptModels { get; set; } = new List<ReceiptDto>();
        public List<OutletModel> OutletModels { get; set; }=new List<OutletModel>();
        public IEnumerable<ItemModel> ItemModels { get; set; }=new List<ItemModel>();
        public ReceiptComponent()
        {
            
        }
        public async Task Filter()
        {
            Guid receiptId=Guid.NewGuid();
            if (outletId == Guid.Empty)
            {
                outletId = Guid.Empty;
            }
            if(String.IsNullOrEmpty(receiptID))
            {
                receiptId= Guid.Empty;
            }
            if (!(String.IsNullOrEmpty(receiptID)))
            {
                receiptId = Guid.Parse(receiptID);
            }
            string token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/SaleItems?outletId={outletId}&startDate={startDate}&endDate={endDate}&receiptId={receiptId}");
            //var request = new HttpRequestMessage(HttpMethod.Get, $"api/SaleItems");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            ReceiptModels = JsonSerializer.Deserialize<List<ReceiptDto>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        public async Task Outlets()
        {
            string token = await sessionStorage.GetItemAsync<string>("Token");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Outlets");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var respone = await Http.SendAsync(request);
            var body = respone.Content.ReadAsStringAsync();
            string result = body.Result;
            OutletModels = JsonSerializer.Deserialize<List<OutletModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            //Add All Outlets
            OutletModels.Insert(0,new OutletModel()
            {
                Id = Guid.Empty,
                Name = "All Outlets"
            });
        }
    }
}
