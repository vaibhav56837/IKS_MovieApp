using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Entity
{
    public class BookingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

       
        [ForeignKey("userModel")]
        public int UId { get; set; }
        public UserModel userModel { get; set; }


        [ForeignKey("movieModel")]
        public int MId { get; set; }
        public MovieModel movieModel { get; set; }


        [ForeignKey("theatreModel")]
        public int TId { get; set; }
        public TheatreModel theatreModel { get; set; }


        public string Date { get; set; }
       
        public string ShowTime { get; set; }
       

        public int Seats { get; set; }


    }
}
