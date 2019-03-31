using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resturant_System.Models
{
    public class User_Type
    {
        [Key]
        public int Id { get; set; }
        public string User_type { get; set; }
    }
}