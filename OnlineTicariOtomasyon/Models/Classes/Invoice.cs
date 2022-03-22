using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string SerialNumber { get; set; }
        public string RowNumber { get; set; }
        public DateTime Date { get; set; }
        public string TaxAdmin { get; set; } // vergi daireleri gelince değişecek
        public string Time { get; set; }
        public string Submitter { get; set; }
        public string Receiver { get; set; }
        public decimal Total { get; set; }
        public bool IsActive { get; set; }

        public ICollection<InvoiceRow> InvoiceRows { get; set; }

    }
}