using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class MovieShowTime : IMovieShowTime
    {
        MovieDBContext _movieDBContext;
        public MovieShowTime(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public string InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
           _movieDBContext.movieShowTimeModel.Add(movieShowTimeModel);
            _movieDBContext.SaveChanges();
            return "Inserted";
        }

        public List<MovieShowTimeModel> ShowMovieTime()
        {
            return _movieDBContext.movieShowTimeModel.ToList();
        }
    }
}
