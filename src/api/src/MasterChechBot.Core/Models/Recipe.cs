using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterChechBot.Core.Models
{
    [Table("Recipe")]
    public class Recipe
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Column("Description")]
        public string Descript { get; set; }

        public DateTime RegisterRecord { get; set; }

        public DateTime? RegisterUpdate { get; set; }

        public virtual Category Category { get; set; }
    }
}
