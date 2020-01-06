using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_code_frest.Models
{
    public class EmailResetPassword
    {
        [Display(Name = "Enter Email : ")]
        public string Email_To_Recover { get; set; }

    }
}