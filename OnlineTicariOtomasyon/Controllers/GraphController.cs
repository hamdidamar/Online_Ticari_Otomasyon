using OnlineTicariOtomasyon.Models.Classes;
using OnlineTicariOtomasyon.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GraphController : Controller
    {
        Context ctx = new Context();
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryAndProductCountGraph()
        {
            var graph = new Chart(600, 600);
            graph.AddTitle("Kategori - Ürün Stok Grafiği")
                 .AddLegend("Stok")
                 .AddSeries("Kategoriler", xValue: new[] { "mobilya", "beyaz eşya", "teknoloji" }, yValues: new[] { 76, 97, 138 })
                 .Write();
            return File(graph.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult ProductStockGraph()
        {
            var graph = new Chart(600, 600);
            graph.AddTitle("Ürün Stok Grafiği")
                 .AddSeries(chartType: "Pie", xValue: ctx.Products.Where(x => x.IsActive).Select(x => x.Name).ToArray(), yValues: ctx.Products.Where(x => x.IsActive).Select(x => x.Stock).ToArray())
                 .Write();
            return File(graph.ToWebImage().GetBytes(), "image/jpeg");
        }

        [HttpGet]
        public ActionResult ProductAndStockGraph()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductAndStockGraph(int id=1)
        {
            JsonResponseMessage message = new JsonResponseMessage();
            var list = ctx.Products.Where(x => x.IsActive).Select(y => new
            {
                Name = y.Name,
                Stock = y.Stock
            }).ToList();

            message.data = list;
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}