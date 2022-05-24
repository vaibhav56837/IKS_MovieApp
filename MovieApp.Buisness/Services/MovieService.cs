using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class MovieService
    {
        IMovie _iMovie;
        public MovieService(IMovie imovie)
        {
            _iMovie = imovie;
        }

        public string Register(MovieModel movieModel)
        {
            return _iMovie.Register(movieModel);
        }

        public object SelectMovies()
        {
            return _iMovie.SelectMovies();
        }

        public string UpdateMovie(MovieModel movieModel)    
        {
            return _iMovie.UpdateMovie(movieModel);
        }

        public string UpdateMovieDetails(MovieModel movieModel)
        {
            return _iMovie.UpdateMovieDetails(movieModel);
        }
        
        public string DeleteMovie(int MovieId)
        {
            return _iMovie.DeleteMovie(MovieId);
        }


        public MovieModel GetSpecificMovie(int id)
        {
            return (_iMovie.GetSpecificMovie(id));
        }
    }
}
