using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieApp.Entity
{
    public class MovieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string MovieDescription { get; set; }

        public string MovieType { get; set; }

        public string MovieLanguage { get; set; }

     // public  byte[] ImgPoster { get; set; }

    }
}
