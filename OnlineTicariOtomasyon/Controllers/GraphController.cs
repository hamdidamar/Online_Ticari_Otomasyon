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
    }
}