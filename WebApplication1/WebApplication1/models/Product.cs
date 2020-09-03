namespace WebApplication1.models
{
    public class Product
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public virtual Category Category { get; set; }
        public int[] Ratings { get; set; }
    }
}