using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels
{
   public class LogInVM
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
    public class ForgotPasswordVM
    {
        [Display(Name = "Email")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        [EmailAddress(ErrorMessage = "your {0} address is not valid")]
        [Required(ErrorMessage = "please fill in your {0}")]
        public string Email { get; set; }
    }

    public class SignUpVM
    {
        [Display(Name = "Username")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        [Required(ErrorMessage = "please fill in your {0}")]
        public string Username { get; set; }

        [Display(Name = "Email")]    
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        [EmailAddress(ErrorMessage = "your {0} address is not valid")]
        [Required(ErrorMessage = "please fill in your {0}")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "please fill in your {0}")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Password and Repassword are not equal")]
        [Required(ErrorMessage ="please fill in in Repassword")]
        public string RePassword { get; set; }


    }

   public class ResetPasswordVM
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "please fill in your {0}")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Repassword are not equal")]
        [Required(ErrorMessage = "please fill in in Repassword")]
        public string RePassword { get; set; }
        public String ActiveCode { get; set; }
    }


}
