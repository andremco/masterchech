using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace MasterChechBotWebApi.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome da categoria é obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho do campo nome da categoria é até 100 caracteres")]
        public string Name { get; set; }


        public static ICollection<CategoryViewModel> Convert(ICollection<Category> categories)
        {

            var destiny = new List<CategoryViewModel>();

            if (categories != null)
            {
                foreach (var origin in categories)
                {
                    destiny.Add(new CategoryViewModel()
                    {
                        Id = origin.Id,
                        Name = origin.Name
                    });
                }
            }

            return destiny;
        }
    }
}
