using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NamaShow.Core.VeiwModels.UserViewModelForAdmin;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.Services;
using NamaShow.DataLayer.Entities;
using NamaShow.Core.Security;
using NamaShow.Core.Convertors;
using Generator;
using System.IO;
using NamaShow.Core.Utilities;


namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserManegerController : Controller
    {
        private IUserService _userService;
        private IPermissionService _permissionService;
        public UserManegerController(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }
        public IActionResult Index(int page=1)
        {
            var model = _userService.GetListOfUsser(page, 2);


            return View(model);
        }
      
        public IActionResult Create()
        {
           // ViewData["Roles"] = _permissionService.GetListOfRole();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserByAdmin model, List<int> UserRoles)
        {
            if (!ModelState.IsValid)
                return View("Create",model);

            model.Email = FixedText.FixEmail(model.Email);

            if (_userService.IsExistEmail(model.Email))
            {
                ModelState.AddModelError("Email", "email is not valid");
                return View(model);
            }
           
            if (UserRoles.Count == 0)
            {
                ModelState.AddModelError("Family", "you have to select at least one role");
                return View(model);
            }

            if (_userService.IsExistUsername(model.Username))
            {
                ModelState.AddModelError("Username", "username is not valid");
                return View(model);
            }

            _permissionService.AddRoleToUser(UserRoles, _userService.CreateUserByAdmin(model));

           

            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           ViewBag.Role = _permissionService.GetListOfRole();
            var model = _userService.GetUserForEdit(id);
           model.Password= PasswordHelper.DecodeFrom64(model.Password);


            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditUserByAdmin model, List<int> UserRoles)
        {
            if (!ModelState.IsValid)
                return View();
            model.Email = FixedText.FixEmail(model.Email);
            var user = _userService.GetUserById(model.UserId);

            model.Email = FixedText.FixEmail(model.Email);

            if (_userService.IsExistEmail(model.Email) && model.Email != user.Email)
            {
                ModelState.AddModelError("Email", "email is not valid");
                return View();
            }

            if (UserRoles.Count == 0)
            {
                ModelState.AddModelError("Family", "you have to select at least one role");
                return View();
            }

            if (_userService.IsExistUsername(model.Username) && user.Username!=model.Username)
            {
                ModelState.AddModelError("Username", "username is not valid");
                return View();
            }

            _permissionService.UpdateRoleToUser(UserRoles, _userService.EditUserByAdmin(model));



            return Redirect("Index");
        }

        public IActionResult Delete(int id)
        {
            _userService.DeleteUserById(id);
            return Redirect(Request.Headers["Referer"].ToString());            
        }
    }
}
