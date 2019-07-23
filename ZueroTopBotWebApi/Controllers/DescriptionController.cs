using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using ZueroTopBotWebApi.Models;

namespace ZueroTopBotWebApi.Controllers
{
    [Route("api/[controller]")]
    public class DescriptionController : BaseController
    {
        private readonly UnitOfWork _uow;

        public DescriptionController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET api/description
        [HttpGet]
        public IActionResult Get()
        {
            var descriptions = DescriptionViewModel.Convert(_uow.DescriptionRepository.Get().ToList());

            if (descriptions != null)
            {
                return Response(descriptions);
            }

            return Response();
        }

        // GET api/description/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var description = _uow.DescriptionRepository.GetByID(id);

            if (description != null)
            {
                return Response(description);
            }

            return Response();
        }

        // POST api/description
        [HttpPost]
        public IActionResult Post([FromBody]DescriptionViewModel descriptionVm)
        {
            if (ModelState.IsValid)
            {
                var description = new Description()
                {
                    CategoryId = descriptionVm.CategoryId,
                    Descript = descriptionVm.Description,
                    RegisterRecord = DateTime.Now
                };

                //TODO validar para não criar uma mesma descrição através do nome
                _uow.DescriptionRepository.Insert(description);
                _uow.Save();

                return Response();
            }

            return Response();
        }

        // PUT api/description
        [HttpPut]
        public IActionResult Put([FromBody]DescriptionViewModel descriptionVm)
        {
            if (ModelState.IsValid)
            {
                var description = _uow.DescriptionRepository.GetByID(descriptionVm.Id);

                if (description != null)
                {
                    description.CategoryId = descriptionVm.CategoryId;
                    description.Descript = descriptionVm.Description;
                    description.RegisterUpdate = DateTime.Now;

                    _uow.DescriptionRepository.Update(description);
                    _uow.Save();
                }
            }

            return Response();
        }

        // DELETE api/description/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _uow.DescriptionRepository.Delete(id);
            _uow.Save();
            return Response();
        }
    }
}
