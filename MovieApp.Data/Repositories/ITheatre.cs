using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Repositories
{
    public interface ITheatre
    {
        public string Register(TheatreModel theatreModel);
        
        public void UpdateTheatre(TheatreModel theatreModel);

        public void DeleteTheatre(int tId);

        public object SelectTheatres();

        public TheatreModel GetSpecificTheatre(int tId);
        
    }
}
