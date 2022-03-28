using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class TodoController : Controller
    {
        Context ctx = new Context();
        // GET: Todo
        public ActionResult Index()
        {
            var customerCount = ctx.Customers.Where(x => x.IsActive).Count();
            var productCount = ctx.Products.Where(x => x.IsActive).Count();
            var categoryCount = ctx.Categories.Where(x => x.IsActive).Count();
            var cityCount = ctx.Customers.Where(x => x.IsActive).Select(x=>x.Address).Distinct().Count();
            var todos = ctx.TaskTodos.Where(x => x.IsActive).ToList();

            ViewBag.customerCount = customerCount;
            ViewBag.productCount = productCount;
            ViewBag.categoryCount = categoryCount;
            ViewBag.cityCount = cityCount;
            return View(todos);
        }
    }
}