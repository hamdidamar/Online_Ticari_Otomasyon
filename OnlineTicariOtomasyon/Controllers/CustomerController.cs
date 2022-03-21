using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        Context ctx = new Context();
        // GET: Customer
        public ActionResult Index()
        {
            var customers = ctx.Customers.Where(x => x.IsActive).ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            customer.IsActive = true;
            ctx.Customers.Add(customer);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = ctx.Customers.Find(id);
            customer.IsActive = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var customer = ctx.Customers.Find(id);
            return View("Update", customer);
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            var newCustomer = ctx.Customers.Find(customer.CustomerId);
            newCustomer.Name = customer.Name;
            newCustomer.Surname = customer.Surname;
            newCustomer.Phone = customer.Phone;
            newCustomer.Mail = customer.Mail;
            newCustomer.Address = customer.Address;
            newCustomer.IsActive = customer.IsActive;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CustomerOrders(int id)
        {
            var orders = ctx.Orders.Where(x => x.IsActive && x.CustomerId == id).ToList();
            var customer = ctx.Customers.Where(x => x.CustomerId == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.customer = customer;
            return View(orders);
        }


    }
}