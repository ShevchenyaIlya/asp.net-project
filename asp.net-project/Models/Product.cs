using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp.net_project.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool InStock { get; set; }
        //TODO: Don't forget to delete this line of code. 
        public Nullable<int> CategoryId { get; set; }
        //TODO: Don't forget to correct next line of code. 
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public int[] Ratings { get; set; }
    }
}
