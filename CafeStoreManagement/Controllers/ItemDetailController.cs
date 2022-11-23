using CafeStoreManagement.Features;
using CafeStoreManagement.Features.ItemDetail.Response;
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
        [HttpPost]
        public async Task<List<ItemDetailCommand>> post([FromBody] List<ItemDetailCommand> items) => await _logic.PostItemDetail(items);
        [HttpGet]
        public async Task<IEnumerable<ItemDetailResponse>> get()=> await _logic.GetItemDetail();
                                                                 
                                                                 

        [HttpDelete]
        public async Task<Guid> delete(Guid id, bool isDeleted) => await _logic.DeleteItemDetail(id,isDeleted);
    }
}
