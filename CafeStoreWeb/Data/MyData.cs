using Microsoft.JSInterop;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.JSInterop;
using System;
using ClosedXML.Excel;
using System.Data;

namespace CafeStoreWeb.Data
{
    public class MyData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public MyData()
        {
            //GetData();
        }
        static public List<MyData> GetData()
        {
            var data=new List<MyData>();
            for (int i = 1; i <= 10; i++)
            {
                var obj = new MyData()
                {
                    Id=i,
                    Name=$"Name {i}"
                };
                data.Add(obj);
            }
            return data;
        }
        
    }
    public class ExportDataFile
    {
        /// <summary>
        /// Exports ClosedXML Excel Workbook as a browser client download
        /// </summary>
        /// <param name="iJsRuntime">Interop JavaScript Runtime or IJSRuntime</param>
        /// <param name="workbook">ClosedXML IXLWorkbook</param>
        /// <param name="fileName">String of filename to be exported without .xlsx extension</param>
        /// <returns>Async Task</returns>
        public static async Task ExportToFileAsync(IJSRuntime iJsRuntime, ExcelPackage workbook, string fileName)
        {
            // Convert Excel Workbook to ByteArray
            byte[] fileByteArray;
            string fileTypeString = "data: application / vnd.openxmlformats - officedocument.spreadsheetml.sheet; base64";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                fileByteArray = memoryStream.ToArray();
            }
            // Export as Excel Workbook via JavaScript
            await iJsRuntime.InvokeAsync<ExportDataFile>(
                "DownloadFile",
                fileName + ".xlsx",
                fileTypeString,
                Convert.ToBase64String(fileByteArray)
            );
        }
        
    }
}
