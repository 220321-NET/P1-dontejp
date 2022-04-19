﻿using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IP0BL _bl;

        public ProductController(IP0BL bl)
        {
            _bl = bl;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<int> GetProduct(int item, int VillageID)
        {
            return await _bl.GetProduct(item, VillageID);
        }

        // GET api/<ProductController>/5
       // [HttpGet("{id}")]
       // public string Get(int id)
       // {
       //     return "value";
       // }

        // POST api/<ProductController>
       // [HttpPost]
       // public void Post([FromBody] string value)
       // {
       // }

        // PUT api/<ProductController>/5
       // [HttpPut("{id}")]
       // public void Put(int id, [FromBody] string value)
       // {
       // }

        // DELETE api/<ProductController>/5
       // [HttpDelete("{id}")]
       // public void Delete(int id)
       //{
       // }
    }
}