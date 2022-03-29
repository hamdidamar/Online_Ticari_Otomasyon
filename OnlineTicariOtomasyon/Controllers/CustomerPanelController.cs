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
    }
}