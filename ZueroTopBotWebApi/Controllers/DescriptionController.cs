using System;
using System.Collections.Generic;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ZueroTopBotWebApi.Controllers
{
    [Route("api/[controller]")]
    public class DescriptionController : Controller
    {
        private readonly UnitOfWork _uow;

        public DescriptionController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Bocó", "Trouxa", "Sfilkis" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "null";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
