using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
using MovieApp.Data.DataConnection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace MovieApp.Data.Repositories
{
    public class User : IUser
    {
        MovieDBContext _movieDBContext;
        public User(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }


        public UserModel Login(UserModel userModel)
        {
            UserModel userData = null;
            var user = _movieDBContext.userModel.Where(u => u.Email == userModel.Email && u.Password == userModel.Password).ToList();
            if (user.Count > 0)
                userData = user[0];
            return userData;
        }



        public string Register(UserModel userModel)
        {
            string msg = "";
            _movieDBContext.userModel.Add(userModel);
            _movieDBContext.SaveChanges();
            msg = "Inserted";
            return msg;
        }

        public List<UserModel> SelectUsers()
        {
            // select * from 
            List<UserModel> userList= _movieDBContext.userModel.ToList();
            return userList;
        }

       

       public void DeleteUser(int UserId)
        {
            UserModel user = _movieDBContext.userModel.Find(UserId);
            _movieDBContext.userModel.Remove(user);
            _movieDBContext.SaveChanges();
        }



        public void UpdateUser(UserModel userModel)
        {
            _movieDBContext.Entry(userModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();

        }

        public UserModel GetSpecificUsers(int UserId)
        {
            return _movieDBContext.userModel.Find(UserId);
        }
    }
}
