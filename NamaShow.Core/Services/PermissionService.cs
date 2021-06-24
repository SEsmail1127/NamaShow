using NamaShow.Core.Services.InterFaces;
using NamaShow.DataLayer.Context;
using NamaShow.DataLayer.Entities;
using NamaShow.DataLayer.Entities.Permision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private NamaShowContext _db;
        public PermissionService(NamaShowContext db)
        {
            _db = db;
        }

        public void AddPermissionsToRole(int roleId, List<int> permission)
        {
            throw new NotImplementedException();
        }

        public void AddRoleToUser(List<int> roleId, int userId )
        {
            foreach (var item in roleId)
            {
                _db.UserRoles.Add(new UserRole
                {
                    RoleId = item,
                    UserId = userId
                });
                _db.SaveChanges();
            }
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            throw new NotImplementedException();
        }

        public void DeletePermission(int id)
        {
            throw new NotImplementedException();
        }

        public List<Permission> GetAllPermission()
        {
            throw new NotImplementedException();
        }

        public List<Permission> GetListOfPermission()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetListOfRole()
        {
            return _db.Roles.ToList();
        }

        public List<Permission> GetNodeOfPermission(int ParentId)
        {
            throw new NotImplementedException();
        }

        public Permission GetPermissionById(int id)
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsUserHaveRole(string username, int RoleId)
        {
            var UserId = _db.Users.SingleOrDefault(c => c.Username == username).UserId;
            List<UserRole> UserRoles = _db.UserRoles.Where(c => c.UserId == UserId).ToList();
            return UserRoles.Any(c => c.RoleId == RoleId);
        }

        public List<int> PermissionsRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePermission(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
            throw new NotImplementedException();
        }
        public void UpdateRoleToUser(List<int> roleId, int userId)
        {
            
            _db.UserRoles.Where(c => c.UserId == userId).ToList().ForEach(r => _db.UserRoles.Remove(r));
            AddRoleToUser(roleId, userId);
        }
    }
}
