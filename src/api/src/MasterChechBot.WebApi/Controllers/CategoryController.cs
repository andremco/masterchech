using System;
using System.Linq;
using Core.Models;
using Core.Repositories;
using MasterChechBotWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterChechBotWebApi.Controllers
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
            var categories = CategoryViewModel.Convert(_uow.CategoryRepository.Get().ToList());

            if (categories != null)
            {
                return Response(categories);
            }

            return Response();
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _uow.CategoryRepository.GetByID(id);

            if (category != null)
            {
                return Response(category);
            }

            return Response();
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
                //TODO validar para não criar uma mesma categoria através do nome
                _uow.CategoryRepository.Insert(category);
                _uow.Save();
            }

            return Response();
        }

        // PUT api/category
        [HttpPut]
        public IActionResult Put([FromBody]CategoryViewModel categoryVm)
        {
            if (ModelState.IsValid)
            {
                var category = _uow.CategoryRepository.GetByID(categoryVm.Id);

                if (category != null)
                {
                    category.Name = categoryVm.Name;
                    category.RegisterUpdate = DateTime.Now;
                    _uow.CategoryRepository.Update(category);
                    _uow.Save();
                }
            }

            return Response();
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _uow.CategoryRepository.Delete(id);
            _uow.Save();
            return Response();
        }
    }
}
