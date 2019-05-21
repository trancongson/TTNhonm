using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BTL_TTNhom.Areas.Admin.Models
{    
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời bạn nhập User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}