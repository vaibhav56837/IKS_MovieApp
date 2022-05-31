using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IMovieShowTime
    {
        string InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel);
        List<MovieShowTimeModel> ShowMovieTime();
    }
}
