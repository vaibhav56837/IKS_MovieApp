using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class UserService
    {
        IUser _iuser;
        public UserService(IUser user)
        {
            _iuser = user;
        }
        public string Register(UserModel userModel)
        {
            return _iuser.Register(userModel);
        }
        public Object selectUsers()
        {
            return _iuser.SelectUsers();
        }

         public void DeleteUser(int UserId)
        {
            _iuser.DeleteUser(UserId);
        }

        public void UpdateUser(UserModel userModel)
        {
            _iuser.UpdateUser(userModel);
        }

        public UserModel GetSpecificUsers(int UserId)
        {
            return(_iuser.GetSpecificUsers(UserId));
        }
    }
}
