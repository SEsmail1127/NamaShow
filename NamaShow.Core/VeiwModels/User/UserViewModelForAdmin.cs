using Microsoft.AspNetCore.Http;
using NamaShow.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.UserViewModelForAdmin
{

    public class CreateUserByAdmin
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 30, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        [EmailAddress(ErrorMessage = "your {0} address is not valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 15, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Password { get; set; }

        [Display(Name = "Name")]
        [MaxLength(30, ErrorMessage = "{0} cant longer than {1}")]
        public string Name { get; set; }

        [Display(Name = "Family")]
        [MaxLength(30, ErrorMessage = "{0} cant longer than {1}")]
        public string Family { get; set; }
        [Display(Name = "Picture")]
        public IFormFile UserPicture { get; set; }
    }
    public class EditUserByAdmin
    {
        public int UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 30, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        [EmailAddress(ErrorMessage = "your {0} address is not valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 15, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Password { get; set; }

        [Display(Name = "Name")]
        [MaxLength(30, ErrorMessage = "{0} cant longer than {1}")]
        public string Name { get; set; }

        [Display(Name = "Family")]
        [MaxLength(30, ErrorMessage = "{0} cant longer than {1}")]
        public string Family { get; set; }
        [Display(Name = "Picture")]
        public IFormFile UserPicture { get; set; }
        public bool IsActive { get; set; }
    }

    public class IndexUserForAdmin
    {
        public List<User> Users { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }

    }

}

