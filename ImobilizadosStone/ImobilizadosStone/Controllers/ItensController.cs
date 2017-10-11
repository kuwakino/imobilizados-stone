using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/itens")]
    public class ItensController : Controller
    {
        // GET api/itens
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/itens?status={status}
        [HttpGet]
        public IEnumerable<string> Get([FromQuery] string status)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/itens/{id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/itens
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/itens/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/itens/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
