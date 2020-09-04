using System.ComponentModel.DataAnnotations;

namespace WebApplication1.models
{
    public class ShoppingDetail
    {
        public int ShoppingDetailId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Addres { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int OrderId { get; set; }
        public decimal AmountPaid { get; set; }
        [Required]
        public string PaymentType { get; set; }

    }
}