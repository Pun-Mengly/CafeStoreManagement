using CafeStoreManagement.Features;
using CafeStoreManagement.Models;

namespace CafeStoreManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = UserRoles.Admin)]
    public class ItemsController : ControllerBase
    {
        private readonly IBusinessLogic _logic;
        private readonly DataContext context;
        public ItemsController(IBusinessLogic logic, DataContext context)
        {
            _logic = logic;
            this.context = context;
        }        
        [HttpPost]
        public async Task<object> post([FromBody] List<ItemCommand> items)=> await _logic.PostItem(items);
        [HttpGet]
        public async Task<IEnumerable<ItemResponse>> get() => await _logic.GetItems();
        [HttpPut]
        public async Task<ItemCommand> put(ItemCommand item) => await _logic.PutItem(item);
        [HttpDelete]
        public async Task<Guid> delete( Guid id,bool deleted) => await _logic.DeleteItem(id,deleted);
    }
}
