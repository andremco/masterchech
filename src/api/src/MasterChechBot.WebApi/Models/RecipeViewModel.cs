using MasterChechBot.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterChechBotWebApi.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo categoria é obrigatório")]
        public int CategoryId { get; set; }

        public string NameCategory { get; set; }

        [MaxLength(250, ErrorMessage = "O tamanho do campo descrição é até 250 caracteres")]
        public string Description { get; set; }

        public static ICollection<RecipeViewModel> Convert(ICollection<Recipe> recipes)
        {
            var destiny = new List<RecipeViewModel>();

            if (recipes != null)
            {
                foreach (var origin in recipes)
                {
                    destiny.Add(new RecipeViewModel()
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
