using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context ctx = new Context();
        // GET: CustomerPanel
        [Authorize]
        public ActionResult Index()
        {
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var customer = ctx.Customers.Where(x => x.IsActive && x.CustomerId == CustomerId).FirstOrDefault();
            ViewBag.customer = customer;
            return View(customer);
        }

        public ActionResult Profile(Customer customer)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Orders()
        {
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var orders = ctx.Orders.Where(x => x.IsActive && x.CustomerId == CustomerId).ToList();
            return View(orders);
        }

        public ActionResult MyMessages()
        {
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var customer = ctx.Customers.Where(x => x.IsActive && x.CustomerId == CustomerId).FirstOrDefault();
            var messages = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).ToList();
            var inboxCount = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).Count();
            var sendCount = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).Count();
            var deletedCount = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).Count();
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendCount = sendCount;
            ViewBag.deletedCount = deletedCount;
            return View(messages);
        }

        public ActionResult SendMessages()
        {
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var customer = ctx.Customers.Where(x => x.IsActive && x.CustomerId == CustomerId).FirstOrDefault();
            var messages = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).ToList();
            var inboxCount = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).Count();
            var sendCount = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).Count();
            var deletedCount = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).Count();
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendCount = sendCount;
            ViewBag.deletedCount = deletedCount;
            return View(messages);
        }
    }
}