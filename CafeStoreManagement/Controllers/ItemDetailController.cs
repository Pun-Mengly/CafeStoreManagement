using CafeStoreManagement.Features;
using CafeStoreManagement.Features.ItemDetail.Response;
using CafeStoreManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class ItemDetailController : ControllerBase
    {

        private readonly IBusinessLogic _logic;
        public ItemDetailController(IBusinessLogic logic)
        {
            _logic = logic;
        }
        //[HttpPost]
        //public async Task<List<ItemDetailCommand>> post([FromBody] List<ItemDetailCommand> items) => await _logic.PostItemDetail(items);
        [HttpGet]
        public async Task<IEnumerable<ItemDetailResponse>> get()=> await _logic.GetItemDetail();

        [HttpPut]
        public async Task<ItemDetailCommand> put([FromBody] ItemDetailCommand items) => await _logic.UpdateItemDetail(items);

        [HttpDelete]
        public async Task<Guid> delete(Guid id, bool isDeleted) => await _logic.DeleteItemDetail(id,isDeleted);
        [HttpPost]
        public async Task<ItemModel> postV2([FromBody] ItemModel items) => await _logic.postItemV2(items);
        [HttpGet]
        [Route("get-item-pricing")]
        public async Task<double> getPrice(Guid itemId, Guid sizeId, Guid OutletId, int qty) => await _logic.GetItemPricing(itemId,sizeId,OutletId,qty);
        [HttpGet]
        [Route("get-item-sizes")]
        public async Task<IEnumerable<SizeModel>> getItemSizes(Guid itemId) => await _logic.GetItemSize(itemId);
        [HttpGet]
        [Route("get-item-outlets")]
        public async Task<IEnumerable<OutletModel>> getItemOutlets (Guid itemId) => await _logic.GetItemOutlet(itemId);

    }
}
