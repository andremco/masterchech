using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterChechBot.Core.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RegisterRecord { get; set; }

        public DateTime? RegisterUpdate { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
