using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;
using OnlineTicariOtomasyon.Models.Helpers;

namespace OnlineTicariOtomasyon.Controllers
{
    public class OrderController : Controller
    {
        Context ctx = new Context();
        DropdownHelper dropdownHelper = new DropdownHelper();

        // GET: Order
        public ActionResult Index()
        {
            var orders = ctx.Orders.Where(x => x.IsActive).ToList();
            return View(orders);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var products = dropdownHelper.GetProducts();
            var customers = dropdownHelper.GetCustomers();
            var employees = dropdownHelper.GetEmployees();
            ViewBag.products = products;
            ViewBag.customers = customers;
            ViewBag.employees = employees;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Order order)
        {
            order.Date = DateTime.Now;
            order.IsActive = true;
            ctx.Orders.Add(order);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var products = dropdownHelper.GetProducts();
            var customers = dropdownHelper.GetCustomers();
            var employees = dropdownHelper.GetEmployees();
            ViewBag.products = products;
            ViewBag.customers = customers;
            ViewBag.employees = employees;
            var order = ctx.Orders.Find(id);
            return View("Update", order);
        }

        [HttpPost]
        public ActionResult Update(Order order)
        {
            var newOrder = ctx.Orders.Find(order.OrderId);
            newOrder.ProductId = order.ProductId;
            newOrder.CustomerId = order.CustomerId;
            newOrder.EmployeeId = order.EmployeeId;
            newOrder.Amount = order.Amount;
            newOrder.Price = order.Price;
            newOrder.Total = order.Total;
            newOrder.Date = DateTime.Now;
            newOrder.IsActive = order.IsActive;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var order = ctx.Orders.Where(x => x.IsActive && x.OrderId == id).ToList();
            return View(order);
        }
    }
}