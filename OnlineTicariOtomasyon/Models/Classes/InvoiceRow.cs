using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class InvoiceRow
    {
        [Key]
        public int InvoiceRowId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public bool IsActive { get; set; }

        public Invoice Invoice { get; set; }
    }
}