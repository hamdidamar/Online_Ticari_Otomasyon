using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.ViewModels
{
    public class InvoiceVM
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<InvoiceRow> InvoiceRows { get; set; }
    }
}