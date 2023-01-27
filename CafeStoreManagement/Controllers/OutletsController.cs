using CafeStoreManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CafeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutletsController : ControllerBase
    {
        private readonly IBusinessLogic _logic;
        public OutletsController(IBusinessLogic logic)
        {
            _logic = logic;
        }

        // GET: api/<OutletsController>
        [HttpGet]
        public async Task<IEnumerable<OutletModel>> Get()=> await _logic.GetAllOutlets();

        // GET api/<OutletsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OutletsController>
        [HttpPost]
        public async Task<OutletModel> Post([FromBody] OutletModel model)=>await _logic.CreateOutlet(model);
        

        // PUT api/<OutletsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OutletsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
