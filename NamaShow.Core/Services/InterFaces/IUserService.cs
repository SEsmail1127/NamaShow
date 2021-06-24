using NamaShow.Core.VeiwModels;
using NamaShow.Core.VeiwModels.UserViewModelForAdmin;
using NamaShow.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NamaShow.Core.Services.InterFaces
{
   public interface IUserService
    {
        User GetUserById(int Id);
        User GetUserForEdit(int id);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        int UpdateUser(User user);
        int AddUser(User user);
        void DeleteUserById(int id);
        bool IsExistUsername(string username);
        User LogInWithUsername(string username, string password);
        User LogInWithEmail(string Email,string password);
        bool IsExistEmail(string email);
        User GetUserByActiveCode(string activeCode);
        bool ActiveAccount(string activeCode);

        int CreateUserByAdmin(CreateUserByAdmin model);
        IndexUserForAdmin GetListOfUsser(int currentPage, int PageCalibre);
        int EditUserByAdmin(EditUserByAdmin model);

    }
}
