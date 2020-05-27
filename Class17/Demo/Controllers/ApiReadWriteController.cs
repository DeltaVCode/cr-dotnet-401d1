using System.Collections.Generic;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiReadWriteController : ControllerBase
    {
        // GET: api/ApiReadWrite
        [HttpGet]
        public IEnumerable<Technology> Get()
        {
            return new[] {
                new Technology { Id = 1, Name = ".NET" }
            };
        }

        // GET: api/ApiReadWrite/5
        [HttpGet("{id}", Name = "Get")]
        public Technology Get(int id)
        {
            return new Technology { Id = id, Name = "Whaetver" };
        }

        // POST: api/ApiReadWrite
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ApiReadWrite/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
