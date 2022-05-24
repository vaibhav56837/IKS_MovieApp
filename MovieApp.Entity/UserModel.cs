using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieApp.Entity
{
    public class UserModel
    {
        [Key]// PM
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }// property
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int  Mobile { get; set; }

    }
}
