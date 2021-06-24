using Generator;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels;
using NamaShow.DataLayer.Context;
using NamaShow.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamaShow.Core.Security;
using NamaShow.Core.VeiwModels.UserViewModelForAdmin;
using NamaShow.Core.Utilities;
using FilmeAkbar.Models.Utiltes;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace NamaShow.Core.Services
{
    public class UserService : IUserService
    {
        private NamaShowContext _db;
        public UserService(NamaShowContext db)
        {
            _db = db;
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = GetUserByActiveCode(activeCode);
            if (user == null || user.IsActive == true)
            {
                return false;
            }
            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            UpdateUser(user);
            return true;

        }

        public int AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.UserId;
        }

        public int CreateUserByAdmin(CreateUserByAdmin model)
        {
            User User = new User
            {
                Username = model.Username,
                // Password = PasswordHelper.EncodePasswordMd5(model.Password),


                Email = model.Email,
                IsActive = true,
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Name = model.Name,
                Family = model.Family,
                RegisterDate = DateTime.Now,

            };

            var pass = PasswordHelper.EncodePasswordToBase64(model.Password);

            User.Password = pass;
            if (model.UserPicture != null)
            {
                string imagePath = "";
                User.UserPicture = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.UserPicture.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic/UserAvatar", User.UserPicture);



                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.UserPicture.CopyTo(stream);
                }
                Convertors.ImageConvertor img = new Convertors.ImageConvertor();



                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic/UserAvatarForList", User.UserPicture);

                img.Image_resize(imagePath, thumbPath, 100);
            }


            var id = AddUser(User);
            return id;

        }

        public void DeleteUserById(int id)
        {
            User user = GetUserById(id);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public int EditUserByAdmin(EditUserByAdmin model)
        {
            User User = GetUserById(model.UserId);
            User.Username = model.Username;
            User.Password = PasswordHelper.EncodePasswordToBase64(model.Password);
            User.Email = model.Email;
            User.IsActive = model.IsActive;
            User.ActiveCode = NameGenerator.GenerateUniqCode();
            User.Name = model.Name;
            User.Family = model.Family;


            if (model.UserPicture != null)
            {
                if (model.UserPicture.FileName != User.UserPicture)
                {
                    if (User.UserPicture != null)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic/UserAvatarForList", User.UserPicture);

                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }

                        var SPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic/UserAvatar", User.UserPicture);

                        if (File.Exists(SPath))
                        {
                            File.Delete(SPath);
                        }
                    }


                    string imagePath = "";
                    User.UserPicture = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.UserPicture.FileName);
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic/UserAvatar", User.UserPicture);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        model.UserPicture.CopyTo(stream);
                    }
                    Convertors.ImageConvertor img = new Convertors.ImageConvertor();

                    string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic/UserAvatarForList", User.UserPicture);

                    img.Image_resize(imagePath, thumbPath, 100);


                }
            }

            var id = UpdateUser(User);
            return id;
        }

        public IndexUserForAdmin GetListOfUsser(int currentPage, int PageCalibre)
        {
            var x = Math.Ceiling((double)_db.Users.Count() / PageCalibre);
            return (new IndexUserForAdmin
            {
                Users = _db.Users.OrderByDescending(c => c.UserId).Skip(PageCalibre * (currentPage - 1)).Take(PageCalibre).ToList(),
                CurrentPage = currentPage,
                PageCount = (int)x,
            });

        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _db.Users.SingleOrDefault(t => t.ActiveCode == activeCode);
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users.SingleOrDefault(t => t.Email == email);
        }

        public User GetUserById(int Id)
        {
            return _db.Users.SingleOrDefault(t => t.UserId == Id);
        }

        public User GetUserByUsername(string username)
        {
            return _db.Users.SingleOrDefault(t => t.Username == username);
        }

        public User GetUserForEdit(int id)
        {
            return _db.Users.Where(t => t.UserId == id).Include(t => t.UserRoles).SingleOrDefault();
        }

        public bool IsExistEmail(string email)
        {
            return _db.Users.Any(t => t.Email == email);
        }

        public bool IsExistUsername(string username)
        {
            return _db.Users.Any(t => t.Username == username);
        }

        public User LogInWithEmail(string Email, string password)
        {
            return _db.Users.SingleOrDefault(c => c.Email == Email && c.Password == password);
        }

        public User LogInWithUsername(string username, string password)
        {
            return _db.Users.SingleOrDefault(c => c.Username == username && c.Password == password);
        }

        public int UpdateUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
            return user.UserId;
        }
    }
}
