using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace IntiSolutionApi.Entities
{
    [Table("order")]
    public partial class Order
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("customer_id")]
        [Range(1, 9999, ErrorMessage = "{0} - The client ID is invalid")]
        public int CustomerId { get; set; } = 0;

        [Column("order_date")]
        public DateTime? OrderDate { get; set; } = DateTime.Now;

        /// <summary>
        /// show the items of a order
        /// </summary>
        public virtual List<OrderDetail> Detail { get; set; } = new List<OrderDetail>();
        
    }
}
