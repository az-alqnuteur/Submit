using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_code_frest.Models
{
    public class ResetPassword
    {
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
    }
}