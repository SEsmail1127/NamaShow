using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.DataLayer.Entities.Permision
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public int? ParentId { get; set; }

        public int PermissionRoleId { get; set; }

        #region Relation
        public virtual List<PermissionRole> PermissionRoles { get; set; }
        [ForeignKey("ParentId")]
        public virtual List<Permision.Permission> Permisions { get; set; }
        #endregion


    }
}
