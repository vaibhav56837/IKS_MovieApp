using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Repositories
{
public interface IUser
    {
        public void DeleteUser(int UserId);
        public string Register(UserModel userModel);

        public UserModel Login(UserModel userModel);
        public List<UserModel> SelectUsers();
        public void UpdateUser(UserModel userModel);

        public UserModel GetSpecificUsers(int UserId);

    }
}
