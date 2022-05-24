using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MovieApp.Entity;
using MovieApp.Data.DataConnection;
using Microsoft.EntityFrameworkCore;
namespace MovieApp.Data.Repositories
{
    public class Theatre : ITheatre
    {
        MovieDBContext _movieDBContext;

        public Theatre(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public void DeleteTheatre(int tId)
        {
            TheatreModel theatre = _movieDBContext.theatreModel.Find(tId);
            _movieDBContext.theatreModel.Remove(theatre);
            _movieDBContext.SaveChanges();
        }

        public  string Register(TheatreModel theatreModel)
        {
            string msg = "";
            _movieDBContext.theatreModel.Add(theatreModel);
            _movieDBContext.SaveChanges();
            msg = "Theatre-Details added";
            return msg;
        }

         public object SelectTheatres()
        {
            return _movieDBContext.theatreModel.ToList();
        }

         public void UpdateTheatre(TheatreModel theatreModel)
        {
            _movieDBContext.Entry(theatreModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
        }

        public TheatreModel GetSpecificTheatre(int tId)
        {
            return _movieDBContext.theatreModel.Find(tId);
        }
    }
}
