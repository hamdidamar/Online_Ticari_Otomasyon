using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context ctx = new Context();
        // GET: Gallery
        public ActionResult Index()
        {
            var products = ctx.Products.Where(x => x.IsActive).ToList();
            return View(products);
        }
    }
}