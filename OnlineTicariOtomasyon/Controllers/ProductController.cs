using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;
using OnlineTicariOtomasyon.Models.Helpers;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context ctx = new Context();
        DropdownHelper dropdownHelper = new DropdownHelper();
        // GET: Product
        public ActionResult Index()
        {
            var products = ctx.Products.Where(x => x.IsActive && x.Category.IsActive).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var categories = dropdownHelper.GetCategories();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            product.IsActive = true;
            ctx.Products.Add(product);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = ctx.Products.Find(id);
            product.IsActive = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var categories = dropdownHelper.GetCategories();
            ViewBag.categories = categories;
            var product = ctx.Products.Find(id);
            return View("Update", product);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            var newProduct = ctx.Products.Find(product.ProductId);
            newProduct.Name = product.Name;
            newProduct.Brand = product.Brand;
            newProduct.Stock = product.Stock;
            newProduct.PurchasePrice = product.PurchasePrice;
            newProduct.SalePrice = product.SalePrice;
            newProduct.CategoryId = product.CategoryId;
            newProduct.PhotoPath = product.PhotoPath;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}