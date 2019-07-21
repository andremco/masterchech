using System;
using System.ComponentModel.DataAnnotations;

namespace ZueroTopBotWebApi.Models
{
    public class DescriptionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo categoria é obrigatório")]
        public int CategoryId { get; set; }
        [MaxLength(250, ErrorMessage = "O tamanho do campo descrição é até 250 caracteres")]
        public string Description { get; set; }
    }
}
