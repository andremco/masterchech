using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("description")]
    public class Description
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Column("Description")]
        public string Descript { get; set; }

        public DateTime RegisterRecord { get; set; }

        public DateTime? RegisterUpdate { get; set; }

        public Category Category { get; set; }
    }
}
