using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class MovieShowTimeService
    {
        IMovieShowTime _movieShowTime;
        public MovieShowTimeService(IMovieShowTime movieShowTime)
        {
            _movieShowTime = movieShowTime;
        }

        public string InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return _movieShowTime.InsertMovieShowTime(movieShowTimeModel);
        }
        public List<MovieShowTimeModel>ShowMovieTimeList()
        {
            return _movieShowTime.ShowMovieTime();
        }

        public MovieShowTimeModel GetSpecificMovieShowTimeById(int ShowId)
        {
            return _movieShowTime.GetSpecificMovieShowTimeById(ShowId);
        }

        public string UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return _movieShowTime.UpdateMovieShowTime(movieShowTimeModel);
        }

        public string DeleteMovieShowTime(int ShowId)
        {
            return _movieShowTime.DeletemovieShowTime(ShowId);
        }
    }
}
