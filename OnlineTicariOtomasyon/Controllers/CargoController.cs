using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        Context ctx = new Context();
        // GET: Cargo
        public ActionResult Index()
        {
            var cargoDetails = ctx.CargoDetails.Where(x => x.IsActive).ToList();
            return View(cargoDetails);
        }

        [HttpGet]
        public ActionResult AddDetail()
        {
            string randomCode = Guid.NewGuid().ToString();
            ViewBag.randomCode = randomCode;
            return View();
        }
        [HttpPost]
        public ActionResult AddDetail(CargoDetail cargoDetail)
        {
            cargoDetail.Date = DateTime.Now;
            cargoDetail.IsActive = true;
            ctx.CargoDetails.Add(cargoDetail);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CargoOperation(string id)
        {
            var operations = ctx.CargoOperations.Where(x => x.Code == id).ToList();
            return View(operations);
        }
    }
}