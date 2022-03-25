using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}