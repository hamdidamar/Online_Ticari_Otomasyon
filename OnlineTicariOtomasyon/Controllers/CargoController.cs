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
    }
}