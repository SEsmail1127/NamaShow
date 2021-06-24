using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.DataLayer.Entities.Permision
{
   public class PermissionRole
    {
        public int PermissionRoleId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        #region Relation
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
        #endregion
    }
}
