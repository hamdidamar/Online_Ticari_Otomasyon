using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        Context ctx = new Context();
        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            var productDetail = ctx.ProductDetails.Where(x => x.IsActive && x.ProductId == id).FirstOrDefault();
            return View(productDetail);
        }
    }
}