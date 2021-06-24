using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NamaShow.DataLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "please fill in your {0}")]
        [MaxLength(length: 30, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "please fill in your {0}")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        [EmailAddress(ErrorMessage = "your {0} address is not valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "please fill in your {0}")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Password { get; set; }

        [Display(Name = "Name")]
        [MaxLength(30,ErrorMessage ="{0} cant longer than {1}")]
        public string Name { get; set; }

        [Display(Name = "Family")]
        [MaxLength(30,ErrorMessage ="{0} cant longer than {1}")]
        public string Family { get; set; }
        [Display(Name ="Picture")]
        public string UserPicture { get; set; }
       
        [Display(Name ="Active Condition")]
        public bool IsActive { get; set; } 

        [Display(Name = "ActiveCode")]
        [MaxLength(50, ErrorMessage = "{0} active code cant longer than {1}")]
        public string ActiveCode { get; set; }
        public bool IsDelete { get; set; }

        [Display(Name = "RegisterDate")]
        public DateTime RegisterDate { get; set; }

        #region Relation
        public virtual  List<UserRole> UserRoles { get; set; }
        public virtual List<NamaShow.DataLayer.Entities.Movie.Movie> Movies { get; set; }

        #endregion
    }
}
