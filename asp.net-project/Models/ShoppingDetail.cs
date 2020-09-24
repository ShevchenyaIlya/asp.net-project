using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace asp.net_project.Models
{
    public class ShoppingDetail
    {
        public int ShoppingDetailId { get; set;}
        public Nullable<int> UserID { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public string PaymentType { get; set; }

        public virtual ApplicationUser Client { get; set; }
    }
}