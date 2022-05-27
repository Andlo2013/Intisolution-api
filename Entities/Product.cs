using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace IntiSolutionApi.Entities
{
    [Table("product")]
    public partial class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
        
        [Column("create_date")]
        public DateTime? CreateDate { get; set; }

        [Column("code")]
        public string Code { get; set; }
    }
}
