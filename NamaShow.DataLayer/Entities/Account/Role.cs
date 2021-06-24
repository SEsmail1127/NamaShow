using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamaShow.DataLayer.Entities
{
    public class Role
    {  [Key]
        public int RoleId { get; set; }
        [Required]
        [Display(Name ="Role Of User")]
        public string Title { get; set; }

        #region Relation
        public virtual List<UserRole> UserRoles { get; set; }

        #endregion
    }
}
