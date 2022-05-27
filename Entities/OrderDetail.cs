using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace IntiSolutionApi.Entities
{
    [Table("order_detail")]
    public partial class OrderDetail
    {
        [Column("id")]
        public int Id { get; set; } = 0;

        [Column("order_id")]
        public int OrderId { get; set; } = 0;
        
        [Column("product_id")]
        [Range(1,9999, ErrorMessage = "{0} - Out of range {1} - {2}")]
        public int ProductId { get; set; }

        [Column("unit_price")]
        [Range(0.01,9999,ErrorMessage = "{0} - Out of range {1} - {2}")]
        public decimal UnitPrice { get; set; }

        [Column("quantity")]
        [Range(1, 9999, ErrorMessage = "{0} - Out of range {1} - {2}")]
        public int Quantity { get; set; }

        [Column("total_price")]
        public decimal? TotalPrice { get; set; }
    }
}
