using CafeStoreManagement.Features.ItemDetail.Response;
using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CafeStoreWeb.Data;

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
        public async Task<IEnumerable<ReceiptModel>> Get(Guid outletId, DateTime startDate, DateTime endDate, Guid receiptId) => await _logic.GetReceipts(outletId,startDate,endDate,receiptId);

        [HttpPost]
        public async Task Post([FromBody] List<ReceiptModel> items) => await _logic.PostOrderModel(items);
    

    }
}
