using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;
using OnlineTicariOtomasyon.Models.Helpers;

namespace OnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        Context ctx = new Context();
        DropdownHelper dropdownHelper = new DropdownHelper();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = ctx.Employees.Where(x => x.IsActive).ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var departments = dropdownHelper.GetDepartments();
            ViewBag.departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                var filename = Path.GetFileName(Request.Files[0].FileName);
                var fileextension = Path.GetExtension(Request.Files[0].FileName);
                var path = "~/img/" + filename + fileextension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                employee.PhotoPath = "/img/" + filename + fileextension;
            }
            employee.IsActive = true;
            ctx.Employees.Add(employee);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var employee = ctx.Employees.Find(id);
            employee.IsActive = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var departments = dropdownHelper.GetDepartments();
            ViewBag.departments = departments;
            var employee = ctx.Employees.Find(id);
            return View("Update", employee);
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                var filename = Path.GetFileName(Request.Files[0].FileName);
                var fileextension = Path.GetExtension(Request.Files[0].FileName);
                var path = "~/img/" + filename + fileextension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                employee.PhotoPath = "/img/" + filename + fileextension;
            }
            var newEmployee = ctx.Employees.Find(employee.EmployeeId);
            newEmployee.Name = employee.Name;
            newEmployee.Surname = employee.Surname;
            newEmployee.PhotoPath = employee.PhotoPath;
            newEmployee.DepartmentId = employee.DepartmentId;
            newEmployee.IsActive = employee.IsActive;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EmployeeOrders(int id)
        {
            var orders = ctx.Orders.Where(x => x.IsActive && x.EmployeeId == id).ToList();
            var employee = ctx.Employees.Where(x => x.EmployeeId == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.employee = employee;
            return View(orders);
        }

        public ActionResult Employees()
        {
            var employees = ctx.Employees.Where(x => x.IsActive).ToList();
            return View(employees);
        }
    }
}