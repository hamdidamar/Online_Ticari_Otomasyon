using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context ctx = new Context();
        // GET: Department
        public ActionResult Index()
        {
            var departments = ctx.Departments.Where(x=>x.IsActive).ToList();
            return View(departments);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {
            department.IsActive = true;
            ctx.Departments.Add(department);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var department = ctx.Departments.Find(id);
            department.IsActive = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var department = ctx.Departments.Find(id);
            return View("Update", department);
        }

        [HttpPost]
        public ActionResult Update(Department department)
        {
            var newDepartment = ctx.Departments.Find(department.DepartmentId);
            newDepartment.Name = department.Name;
            newDepartment.IsActive = department.IsActive;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Detail(int id)
        {
            var employees = ctx.Employees.Where(x => x.IsActive && x.DepartmentId == id).ToList();
            var department = ctx.Departments.Where(x => x.DepartmentId == id).Select(y=>y.Name).FirstOrDefault();
            ViewBag.department = department;
            return View(employees);
        }

        [HttpGet]
        public ActionResult EmployeeOrders(int id)
        {
            var orders = ctx.Orders.Where(x => x.IsActive && x.EmployeeId == id).ToList();
            var employee = ctx.Employees.Where(x => x.EmployeeId == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.employee = employee;
            return View(orders);
        }
    }
}