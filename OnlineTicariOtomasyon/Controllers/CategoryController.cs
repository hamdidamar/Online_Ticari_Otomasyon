using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        // GET: Category
        public ActionResult Index()
        {
            var categories = c.Categories.Where(x=>x.IsActive).ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            category.IsActive = true;
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var category = c.Categories.Find(id);
            category.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var category = c.Categories.Find(id);
            return View("Update",category);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            var newCategory = c.Categories.Find(category.CategoryId);
            newCategory.Name = category.Name;
            newCategory.IsActive = category.IsActive;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}