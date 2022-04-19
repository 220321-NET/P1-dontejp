using Microsoft.AspNetCore.Mvc;
using BL;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IP0BL _bl;

        public InventoryController(IP0BL bl)
        {
            _bl = bl;
        }
        // GET: api/<InventoryController>
        [HttpGet("{VillageID}")]
        public async Task<List<Product>> GetInventory(int VillageID)
        {
            return await _bl.GetInventory(VillageID);
        }

        // GET api/<InventoryController>/5
        //[HttpGet]
        //public int GetProduct(int item, int VillageID)
        //{
        //    return _bl.GetProduct(item, VillageID);
        //}

        // POST api/<InventoryController>

        public class Update
        {
            public int item { get; set; }
            public int remaining { get; set; }
            public int VillageID { get; set; }
        }


        //public List<Customer> GetAllCustomers()
        //{
        //    return _repo.GetAllCustomers();
        //}


        // PUT api/<InventoryController>/5
        [HttpPut]
        public void UpdateInventory(Update update)
        {
             _bl.UpdateInventory(update.item,update.remaining,update.VillageID);
        }

        //DELETE api/<InventoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
