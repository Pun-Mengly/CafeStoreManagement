using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class SizesController : ControllerBase
    {
        private readonly IBusinessLogic _logic;
        public SizesController(IBusinessLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<IEnumerable<SizeModel>> get() => await _logic.GetAllSizes();
        
    }
}
