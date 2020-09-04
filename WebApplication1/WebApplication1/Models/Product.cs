using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and maximum 100 characters are allowed", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public bool InStock { get; set; }
        [Required]
        //TODO: Don't forget to delete this line of code. 
        [Range(1, 50)]
        public Nullable<int> CategoryId { get; set; }
        [Required]
        //TODO: Don't forget to correct next line of code. 
        [Range(typeof(int), "1", "500", ErrorMessage = "Invalid quantity")]
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public int[] Ratings { get; set; }
    }
}