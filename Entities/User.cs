using System;
using System.Collections.Generic;

#nullable disable

namespace IntiSolutionApi.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
