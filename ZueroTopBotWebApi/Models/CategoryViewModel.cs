using System;
using System.ComponentModel.DataAnnotations;

namespace ZueroTopBotWebApi.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome da categoria é obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho do campo nome da categoria é até 100 caracteres")]
        public string Name { get; set; }
    }
}
