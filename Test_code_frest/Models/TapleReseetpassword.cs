using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_code_frest.Models
{
    public class TapleReseetpassword
    {
        [Key]
        public int RestPassword_Id { get; set; }

        public int UserId { get; set; }

        public string  Code_send { get; set; }
    }
}