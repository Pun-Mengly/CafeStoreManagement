
namespace CafeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InitailizataionController : ControllerBase
    {
        private readonly IBusinessLogic _logic;

        public InitailizataionController(IBusinessLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public void init() => _logic.InitailizationData();
    }
}
