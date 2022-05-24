using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieApp.Entity
{
    public  class TheatreModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tId { get; set; }

        public string  tName { get; set; }

        public int tCapacity { get; set; }

        public string tClass { get; set; }
        public string tLocation { get; set; }

        public string tAddress { get; set; }

    }
}
