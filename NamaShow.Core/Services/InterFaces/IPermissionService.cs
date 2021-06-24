using NamaShow.DataLayer.Entities;
using NamaShow.DataLayer.Entities.Permision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Services.InterFaces
{
  public  interface IPermissionService
    {
        Permission GetPermissionById(int id);
        List<Permission> GetListOfPermission();
        List<Permission> GetNodeOfPermission(int ParentId);
        void DeletePermission(int id);
        void UpdatePermission(int id);

        #region Roles
        Role GetRoleById(int id);
        List<Role> GetListOfRole();
        void AddRoleToUser(List<int>roleId , int userId );
        void UpdateRoleToUser(List<int> roleId, int userId);
        bool IsUserHaveRole(string username, int RoleId);

        #endregion
        #region Permission
        List<Permission> GetAllPermission();
        void AddPermissionsToRole(int roleId, List<int> permission);
        List<int> PermissionsRole(int roleId);
        void UpdatePermissionsRole(int roleId, List<int> permissions);

        bool CheckPermission(int permissionId, string userName);
        #endregion


    }
}
