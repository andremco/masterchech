using System;
using System.Linq;
using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using ZueroTopBotWebApi.Models;

namespace ZueroTopBotWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly UnitOfWork _uow;

        public CategoryController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET api/category
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _uow.CategoryRepository.Get();

            if (categories != null)
            {
                return Ok(categories);
            }

            return Ok();
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return Ok(new string[] { "Id inválido!" });
            }

            var category = _uow.CategoryRepository.GetByID(id);

            if (category != null)
            {
                return Ok(category);
            }

            return Ok();
        }

        // POST api/category
        [HttpPost]
        public IActionResult Post([FromBody]CategoryViewModel categoryVm)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = categoryVm.Name,
                    RegisterRecord = DateTime.Now
                };
                _uow.CategoryRepository.Insert(category);
                _uow.Save();

                return Response();
            }

            return Response();
        }

        // PUT api/category
        [HttpPut]
        public void Put([FromBody]CategoryViewModel categoryVm)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
