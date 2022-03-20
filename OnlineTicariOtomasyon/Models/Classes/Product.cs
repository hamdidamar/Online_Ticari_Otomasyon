using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }// ilerde marka sınıfı ile değişecek
        public int Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string PhotoPath { get; set; } // ileride fotoğraflar sınıfı ile güncellenecek
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}