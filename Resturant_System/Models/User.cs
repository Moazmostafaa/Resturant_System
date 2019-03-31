using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resturant_System.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("userType")]
        public int TyperID { get; set; }
        public User_Type userType { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        

    }
}