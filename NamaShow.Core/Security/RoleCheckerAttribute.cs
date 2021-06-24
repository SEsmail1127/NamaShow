using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NamaShow.Core.Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Security
{
    public class RoleCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private int _roleId = 0;
        private IPermissionService _permissionService;
        public RoleCheckerAttribute(int RoleId)
        {
            _roleId = RoleId;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string username = context.HttpContext.User.Identity.Name;
                if (!_permissionService.IsUserHaveRole(username, _roleId))
                    context.Result = new RedirectResult("/LogIn");
            }
            else
            {
                context.Result = new RedirectResult("/LogIn");
            }
        }
    }
}
