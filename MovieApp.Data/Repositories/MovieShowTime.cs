using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data.Repositories
{
    public class MovieShowTime : IMovieShowTime
    {
        MovieDBContext _movieDBContext;
        public MovieShowTime(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public string DeletemovieShowTime(int ShowId)
        {
            string msg = "";
            MovieShowTimeModel movieShowTimeModel = _movieDBContext.movieShowTimeModel.Find(ShowId);
            _movieDBContext.movieShowTimeModel.Remove(movieShowTimeModel);
            _movieDBContext.SaveChanges();
            msg = "MovieShowTime Deleted!!!";
            return msg;
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

        public MovieShowTimeModel GetSpecificMovieShowTimeById(int ShowId)
        {
           return _movieDBContext.movieShowTimeModel.Find(ShowId);
            
        }

        public string UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            string msg = "";
            _movieDBContext.Entry(movieShowTimeModel).State= EntityState.Modified;
            _movieDBContext.SaveChanges();
            msg = "MovieShowTime Updated";
            return msg;
        }

        public List<MovieShowTimeModel> GetShowTimesAndDateForSpecificTheatreAndMovie(int mId)
        {
            //MovieShowTimeModel movieShowTimeData = null;
            var movieShowTime = _movieDBContext.movieShowTimeModel.Where(u => u.MovieId == mId).ToList();
            //if (movieShowTime.Count > 0)
            //    movieShowTimeData = movieShowTime[0];
            return movieShowTime;
        }
    }
}
