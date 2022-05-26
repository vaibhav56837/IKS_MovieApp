using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Repositories
{
    public interface IMovie
    {
        public List<MovieModel> SelectMovies();

        public string Register(MovieModel movieModel);

        public string DeleteMovie(int MovieId);

        public string UpdateMovie(MovieModel movieModel);

        public string UpdateMovieDetails(MovieModel movieModel);

        public MovieModel GetSpecificMovie(int MovieId);

    }
}
