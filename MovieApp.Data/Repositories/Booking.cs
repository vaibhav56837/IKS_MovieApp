using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public  class Booking : IBooking
    {
        MovieDBContext _movieDBContext;
        public Booking( MovieDBContext movieDBContext)
        {
            _movieDBContext=movieDBContext;
        }
        public string BookingRegister(BookingModel bookingModel)
        {
            string msg = "";
            _movieDBContext.bookingModel.Add(bookingModel);
            _movieDBContext.SaveChanges();
            msg = "Inserted";
            return msg;
        }
        public List<BookingModel> GetAllBooking()
        {
            return _movieDBContext.bookingModel.ToList();
        }
    }
}
