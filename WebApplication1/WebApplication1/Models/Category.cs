using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name Required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and maximum 100 characters are allowed", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public List<Product> Items { get; set; }
    }
}