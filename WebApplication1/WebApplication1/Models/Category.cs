using System.Collections.Generic;

namespace WebApplication1.models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<Product> Items { get; set; }
    }
}