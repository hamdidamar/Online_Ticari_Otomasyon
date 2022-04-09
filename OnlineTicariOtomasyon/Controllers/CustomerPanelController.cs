using OnlineTicariOtomasyon.Models.Classes;
using OnlineTicariOtomasyon.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context ctx = new Context();
        // GET: CustomerPanel
        [Authorize]
        public ActionResult Index()
        {
            var vm = new CustomerPanelVM();
            
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var customer = ctx.Customers.Where(x => x.IsActive && x.CustomerId == CustomerId).FirstOrDefault();
            ViewBag.customer = customer;
            var orderCount = ctx.Orders.Where(x => x.IsActive && x.CustomerId == customer.CustomerId).Count();
            ViewBag.orderCount = orderCount;

            var totalOrder = ctx.Orders.Where(x => x.IsActive && x.CustomerId == customer.CustomerId).Sum(y => y.Total).GetValueOrDefault(0);
            var totalProduct = ctx.Orders.Where(x => x.IsActive && x.CustomerId == customer.CustomerId).Sum(y => y.Amount).GetValueOrDefault(0);
            ViewBag.totalOrder = totalOrder;
            ViewBag.totalProduct = totalProduct;

            var orders = ctx.Orders.Where(x => x.IsActive && x.CustomerId == customer.CustomerId).OrderByDescending(x => x.Date).ToList();
            var messages = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).OrderByDescending(x => x.Date).ToList();
            vm.Customer = customer;
            vm.Orders = orders;
            vm.Messages = messages;
            return View(vm);
        }
        [HttpPost]
        public ActionResult Profile(Customer customer)
        {
            var newCustomer = ctx.Customers.Find(customer.CustomerId);
            newCustomer.Name = customer.Name;
            newCustomer.Surname = customer.Surname;
            newCustomer.Address = customer.Address;
            newCustomer.Phone = customer.Phone;
            ctx.SaveChanges();
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
            var messages = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).OrderByDescending(x => x.Date).ToList();
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
            var messages = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).OrderByDescending(x => x.Date).ToList();
            var inboxCount = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).Count();
            var sendCount = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).Count();
            var deletedCount = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).Count();
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendCount = sendCount;
            ViewBag.deletedCount = deletedCount;
            return View(messages);
        }

        public ActionResult DeletedMessages()
        {
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var customer = ctx.Customers.Where(x => x.IsActive && x.CustomerId == CustomerId).FirstOrDefault();
            var messages = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).OrderByDescending(x=>x.Date).ToList();
            var inboxCount = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).Count();
            var sendCount = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).Count();
            var deletedCount = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).Count();
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendCount = sendCount;
            ViewBag.deletedCount = deletedCount;
            return View(messages);
        }

        public ActionResult ReadMessage(int id)
        {
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var customer = ctx.Customers.Where(x => x.IsActive && x.CustomerId == CustomerId).FirstOrDefault();
            var messages = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).ToList();
            var inboxCount = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).Count();
            var sendCount = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).Count();
            var deletedCount = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).Count();
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendCount = sendCount;
            ViewBag.deletedCount = deletedCount;

            var message = ctx.Messages.Where(x => x.IsActive && x.MessageId == id).FirstOrDefault();
            return View(message);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var customer = ctx.Customers.Where(x => x.IsActive && x.CustomerId == CustomerId).FirstOrDefault();
            var inboxCount = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).Count();
            var sendCount = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).Count();
            var deletedCount = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).Count();
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendCount = sendCount;
            ViewBag.deletedCount = deletedCount;
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var CustomerId = int.Parse(Session["CustomerId"].ToString());
            var customer = ctx.Customers.Where(x => x.IsActive && x.CustomerId == CustomerId).FirstOrDefault();
            var inboxCount = ctx.Messages.Where(x => x.IsActive && x.To == customer.Mail).Count();
            var sendCount = ctx.Messages.Where(x => x.IsActive && x.From == customer.Mail).Count();
            var deletedCount = ctx.Messages.Where(x => !x.IsActive && x.To == customer.Mail).Count();
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendCount = sendCount;
            ViewBag.deletedCount = deletedCount;

            message.From = customer.Mail;
            message.Date = DateTime.Now;
            message.IsActive = true;
            ctx.Messages.Add(message);
            ctx.SaveChanges();
            return RedirectToAction("MyMessages");
        }

        public ActionResult Cargo(string id)
        {
            var cargoDetails = ctx.CargoDetails.Where(x => x.IsActive && x.Code.Contains(id)).ToList();
            return View(cargoDetails);
        }

        public ActionResult CargoOperation(string id)
        {
            var operations = ctx.CargoOperations.Where(x => x.Code == id).ToList();
            return View(operations);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}