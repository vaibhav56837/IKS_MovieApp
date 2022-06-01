using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;
namespace MovieApp.Data.DataConnection
{
    public class MovieDBContext:DbContext// acting as database
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options):base(options)
        {
          
        }
        public DbSet<UserModel> userModel { get; set; }// acting as table
        public DbSet<MovieModel> movieModel  { get; set; }
        public DbSet<TheatreModel> theatreModel { get; set; }
        
        public DbSet<MovieShowTimeModel> movieShowTimeModel { get; set; }

        public DbSet<BookingModel> bookingModel { get; set; }

    }
}

//Dbset  =table name (UserModel)
