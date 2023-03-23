using CafeStoreManagement.Features.ItemDetail.Response;
using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CafeStoreWeb.Data;
using CafeStoreManagement.DTOs;

namespace CafeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class SaleItemsController : ControllerBase
    {
        private readonly IBusinessLogic _logic;
        public SaleItemsController(IBusinessLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public async Task<IEnumerable<ReceiptDto>> Get(Guid outletId, DateTime startDate, DateTime endDate, Guid receiptId) => await _logic.GetReceipts(outletId,startDate,endDate,receiptId);

        [HttpGet]
        [Route("revenue-outlet")]
        public async Task<IEnumerable<RevenueOutletsDto>> GetRevenueOutlets() => await _logic.GetRevenueOutlets();


        [HttpGet]
        [Route("revenue-outlet-by-year")]
        public async Task<IEnumerable<RevenueOutletByYear>> GetRevenueOutletByYears() => await _logic.GetRevenueOutletByYears();
        [HttpGet]
        [Route("items-pupular")]
        public async Task<IEnumerable<PopularItemDto>> GetItemPopularByCategories() => await _logic.GetItemPopulars();
        [HttpPost]
        public async Task Post([FromBody] List<ReceiptModel> items) => await _logic.PostOrderModel(items);
    

    }
}
