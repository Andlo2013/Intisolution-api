using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace IntiSolutionApi.Entities
{
    [Table("customer")]
    public partial class customer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("identification")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="{0} Is required")]
        public string Identification { get; set; }

        [Column("first_name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Is required")]
        public string FirstName { get; set; }
        
        [Column("last_name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Is required")]
        public string LastName { get; set; }

        [Column("email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Is required")]
        [EmailAddress(ErrorMessage = "Is not a valid mail")]
        public string Email { get; set; } = "";

        [Column("create_date")]
        public DateTime? CreateDate { get; set; }=DateTime.Now;

        [Column("user_id")]
        public int? UserId { get; set; } = 0;
    }
}
