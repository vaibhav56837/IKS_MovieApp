using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.DataConnection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace MovieApp.Data.Repositories
{
    public class Movie : IMovie
    {

        MovieDBContext _movieDBContext;
        public Movie(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public string Register(MovieModel movieModel)
        {
            string msg = "";
            _movieDBContext.movieModel.Add(movieModel);
            _movieDBContext.SaveChanges();
            msg = "Inserted";
            return msg;
        }

        public string DeleteMovie(int MovieId)
        {
            string msg = "";
            MovieModel movie = _movieDBContext.movieModel.Find(MovieId);
            _movieDBContext.movieModel.Remove(movie);
            _movieDBContext.SaveChanges();
            msg = "Deleted Movie!!";
            return msg;
        }

        public string UpdateMovie(MovieModel movieModel)
        {
            string msg = "";
            _movieDBContext.Entry(movieModel).State=EntityState.Modified;
            _movieDBContext.SaveChanges();
            msg = "Movie field updated";
            return msg;
        }
        public string UpdateMovieDetails(MovieModel movieModel)
        {
            string msg = "";
            _movieDBContext.Entry(movieModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
            msg = "Movie field updated";
            return msg;
        }

        public List<MovieModel> SelectMovies()
        {
            return _movieDBContext.movieModel.ToList();
        }


        public MovieModel GetSpecificMovie(int MovieId)
        {
            return _movieDBContext.movieModel.Find(MovieId);
        }
    }
}
