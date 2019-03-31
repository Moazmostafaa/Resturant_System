using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resturant_System.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("category")]
        public int? CategoryID { get; set; }
        public Category category { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}