using CafeStoreManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class CategoriesController : ControllerBase
    {
        private readonly IBusinessLogic _logic;
        public CategoriesController(IBusinessLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryModel>> get() => await _logic.GetAllCategories();
    }
}
