using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace ZueroTopBotWebApi.Models
{
    public class DescriptionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo categoria é obrigatório")]
        public int CategoryId { get; set; }

        public string NameCategory { get; set; }

        [MaxLength(250, ErrorMessage = "O tamanho do campo descrição é até 250 caracteres")]
        public string Description { get; set; }

        public static ICollection<DescriptionViewModel> Convert(ICollection<Description> descriptions)
        {

            var destiny = new List<DescriptionViewModel>();

            if (descriptions != null)
            {
                foreach (var origin in descriptions)
                {
                    destiny.Add(new DescriptionViewModel()
                    {
                        Id = origin.Id,
                        CategoryId = origin.CategoryId,
                        NameCategory = origin.Category.Name,
                        Description = origin.Descript
                    });
                }
            }

            return destiny;
        }
        
    }
}
