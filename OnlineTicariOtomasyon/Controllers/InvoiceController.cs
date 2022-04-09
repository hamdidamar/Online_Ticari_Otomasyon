using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;
using OnlineTicariOtomasyon.Models.ViewModels;

namespace OnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        Context ctx = new Context();
        // GET: Invoice
        public ActionResult Index()
        {
            var invoices = ctx.Invoices.Where(x => x.IsActive).ToList();
            return View(invoices);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Invoice invoice)
        {
            invoice.IsActive = true;
            ctx.Invoices.Add(invoice);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var invoice = ctx.Invoices.Find(id);
            return View("Update", invoice);
        }

        [HttpPost]
        public ActionResult Update(Invoice invoice)
        {
            var newInvoice = ctx.Invoices.Find(invoice.InvoiceId);
            newInvoice.SerialNumber = invoice.SerialNumber;
            newInvoice.RowNumber = invoice.RowNumber;
            newInvoice.Date = invoice.Date;
            newInvoice.TaxAdmin = invoice.TaxAdmin;
            newInvoice.Time = invoice.Time;
            newInvoice.Submitter = invoice.Submitter;
            newInvoice.Receiver = invoice.Receiver;
            newInvoice.Total = invoice.Total;
            newInvoice.IsActive = invoice.IsActive;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var invoiceRows = ctx.InvoiceRows.Where(x => x.IsActive && x.InvoiceId == id).ToList();
            ViewBag.invoiceId = id;
            return View(invoiceRows);
        }

        [HttpGet]
        public ActionResult AddRow(int id)
        {
            var invoiceRow = new InvoiceRow { InvoiceId = id };
            return View(invoiceRow);
        }

        [HttpPost]
        public ActionResult AddRow(InvoiceRow invoiceRow)
        {
            invoiceRow.IsActive = true;
            ctx.InvoiceRows.Add(invoiceRow);
            ctx.SaveChanges();
            return RedirectToAction("/Detail/"+invoiceRow.InvoiceId);
        }

        public ActionResult Dynamic()
        {
            var vm = new InvoiceVM();
            vm.Invoices = ctx.Invoices.Where(x => x.IsActive).ToList();
            vm.InvoiceRows = ctx.InvoiceRows.Where(x => x.IsActive).ToList();
            return View(vm);
        }

        public ActionResult SaveInvoice(Invoice invoice,List<InvoiceRow> invoiceRows)
        {
            invoice.IsActive = true;
            ctx.Invoices.Add(invoice);
            foreach (var row in invoiceRows)
            {
                row.IsActive = true;

                ctx.InvoiceRows.Add(row);
            }
            ctx.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }

    }
}