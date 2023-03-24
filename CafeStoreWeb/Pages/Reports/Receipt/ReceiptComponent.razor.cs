using CafeStoreManagement.DTOs;
using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using CafeStoreWeb.Pages.Outlet;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CafeStoreWeb.Services;

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
        private async void ExportExcelEPPlus()
        {
            List<string> headers = new List<string>() { "Receipt Id", "Item", "Size","Qty","Price","Amount","Total","Cashier","Outlet","OrderDate" };
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create Excel Workbook with data then export
            using (var excelPackage = new ExcelPackage())
            {
                // Create Excel Workbook
                var excelWorksheet = excelPackage.Workbook.Worksheets.Add("Receipt");
                // Header
                foreach (var item in headers)
                {
                    int index = headers.IndexOf(item)+1;
                    excelWorksheet.Cells[1, index].Value = item;
                    excelWorksheet.Cells[1, index].Style.Font.Size = 12;
                    excelWorksheet.Cells[1, index].Style.Font.Bold = true;
                }

                // Record
                foreach (var item in ReceiptModels)
                {
                    int index = 0;
                    if (ReceiptModels.IndexOf(item) == 0)
                    {
                        index = ReceiptModels.IndexOf(item) + 2;
                    }
                    else
                    {
                        index = ReceiptModels.IndexOf(item) + 1;
                    }
                    
                    excelWorksheet.Cells[index, 1].Value = item.ReceiptId;
                    excelWorksheet.Cells[index, 2].Value = item.ItemName;
                    excelWorksheet.Cells[index, 3].Value = item.SizeName;
                    excelWorksheet.Cells[index, 4].Value = item.Qty;
                    excelWorksheet.Cells[index, 5].Value = item.Price;
                    excelWorksheet.Cells[index, 6].Value = item.Amount;
                    excelWorksheet.Cells[index, 7].Value = item.Total;
                    excelWorksheet.Cells[index, 8].Value = item.CashierName;
                    excelWorksheet.Cells[index, 9].Value = item.OutletName;
                    excelWorksheet.Cells[index, 10].Value = item.OrderDate;
                    //Format Date
                    excelWorksheet.Cells[index, 10].Style.Numberformat.Format = "yyyy-mm-dd,hh:mm:ss";

                }
                // Export data
                await ExportDataFile.ExportToFileAsync(JSRunTime, excelPackage, $"Receipt Report {DateTime.Now}");
            }

        }
    }
}
