using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MasterChechBotWebApi.Models;
using MasterChechBot.Core.Repositories;
using MasterChechBot.Core.Models;

namespace MasterChechBotWebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RecipeController : BaseController
    {
        private readonly UnitOfWork _uow;

        public RecipeController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET api/recipe
        [HttpGet]
        public IActionResult Get()
        {
            var descriptions = RecipeViewModel.Convert(_uow.RecipeRepository.Get().OrderBy(d => d.CategoryId).ToList());

            if (descriptions != null)
            {
                return Response(descriptions);
            }

            return Response();
        }

        // GET api/recipe/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var description = _uow.RecipeRepository.GetByID(id);

            if (description != null)
            {
                return Response(description);
            }

            return Response();
        }

        // POST api/recipe
        [HttpPost]
        public IActionResult Post([FromBody]RecipeViewModel descriptionVm)
        {
            if (ModelState.IsValid)
            {
                var description = new Recipe()
                {
                    CategoryId = descriptionVm.CategoryId,
                    Descript = descriptionVm.Description,
                    RegisterRecord = DateTime.Now
                };

                //TODO validar para não criar uma mesma descrição através do nome
                _uow.RecipeRepository.Insert(description);
                _uow.Save();

                return Response();
            }

            return Response();
        }

        // PUT api/recipe
        [HttpPut]
        public IActionResult Put([FromBody]RecipeViewModel descriptionVm)
        {
            if (ModelState.IsValid)
            {
                var description = _uow.RecipeRepository.GetByID(descriptionVm.Id);

                if (description != null)
                {
                    description.CategoryId = descriptionVm.CategoryId;
                    description.Descript = descriptionVm.Description;
                    description.RegisterUpdate = DateTime.Now;

                    _uow.RecipeRepository.Update(description);
                    _uow.Save();
                }
            }

            return Response();
        }

        // DELETE api/recipe/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _uow.RecipeRepository.Delete(id);
            _uow.Save();
            return Response();
        }
    }
}
