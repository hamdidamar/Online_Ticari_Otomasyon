﻿using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context ctx = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            customer.IsActive = true;
            ctx.Customers.Add(customer);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin(Customer c)
        {
            var loginInfo = ctx.Customers.Where(x => x.IsActive && x.Mail == c.Mail && x.Password == c.Password).FirstOrDefault();
            if (loginInfo !=null)
            {
                FormsAuthentication.SetAuthCookie(loginInfo.Mail, false);
                Session["CustomerMail"] = loginInfo.Mail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}