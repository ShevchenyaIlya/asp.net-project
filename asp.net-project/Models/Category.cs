using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp.net_project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public List<Product> Products { get; set; }
    }
}