using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
using MovieApp.Data.Repositories;

namespace MovieApp.Business.Services
{
    public  class TheatreService
    {
        ITheatre _iTheatre;
        public TheatreService(ITheatre iTheatre)
        {
            _iTheatre = iTheatre;
        }

        public string Register(TheatreModel theatreModel)
        {
            return _iTheatre.Register(theatreModel);
        }

        public List<TheatreModel> SelectTheatre()
        {
            return _iTheatre.SelectTheatres();
        }

        public void DeleteTheatre(int tId)
        {
            _iTheatre.DeleteTheatre(tId);
        }
        
        public void UpadateTheatre(TheatreModel theatreModel)
        {
            _iTheatre.UpdateTheatre(theatreModel);
        }

        public TheatreModel GetSpecificTheatre(int tId)
        {
            return _iTheatre.GetSpecificTheatre(tId);
        }
    }
}
