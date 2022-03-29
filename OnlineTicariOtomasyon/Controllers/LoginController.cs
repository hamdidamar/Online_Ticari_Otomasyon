using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context ctx = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            customer.IsActive = true;
            ctx.Customers.Add(customer);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}