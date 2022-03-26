using OnlineTicariOtomasyon.Models.Classes;
using OnlineTicariOtomasyon.Models.Classes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        Context ctx = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            var cards = new List<StatisticCard>
            {
                new StatisticCard{Title="Ürün Sayısı",Value=ctx.Products.Where(x=>x.IsActive).Count().ToString(),Icon="",BackgroundColor="#cd84f1"},
                new StatisticCard{Title="Müşteri Sayısı",Value=ctx.Customers.Where(x=>x.IsActive).Count().ToString(),Icon="",BackgroundColor="#d1d8e0"},
                new StatisticCard{Title="Personel Sayısı",Value=ctx.Employees.Where(x=>x.IsActive).Count().ToString(),Icon="",BackgroundColor="#ff4d4d"},
                new StatisticCard{Title="Kategori Sayısı",Value=ctx.Categories.Where(x=>x.IsActive).Count().ToString(),Icon="",BackgroundColor="#ffaf40"},
                new StatisticCard{Title="Toplam Stok Sayısı",Value=ctx.Products.Where(x=>x.IsActive).Sum(x=>x.Stock).ToString(),Icon="",BackgroundColor="#c56cf0"},
                new StatisticCard{Title="Marka Sayısı",Value= ctx.Products.Where(x=>x.IsActive).Select(x=>x.Brand).Distinct().Count().ToString(),Icon="",BackgroundColor="#a5b1c2"},
                new StatisticCard{Title="Kritik Seviyedeki Ürün Sayısı",Value=ctx.Products.Where(x=>x.IsActive).Count(x=>x.Stock <=20).ToString(),Icon="",BackgroundColor="#ff3838"},
                new StatisticCard{Title="En Yüksek Fiyatlı Ürün",Value= ctx.Products.Where(x=>x.IsActive).OrderByDescending(x=>x.SalePrice).FirstOrDefault().Name,Icon="",BackgroundColor="#ff9f1a"},
                new StatisticCard{Title="En Düşük Fiyatlı Ürün",Value= ctx.Products.Where(x=>x.IsActive).OrderBy(x=>x.SalePrice).FirstOrDefault().Name,Icon="",BackgroundColor="#32ff7e"},
                new StatisticCard{Title="Kasadaki Tutar",Value= ctx.Orders.Where(x=>x.IsActive).Sum(x=>x.Total).ToString(),Icon="",BackgroundColor="#FFC312"},
                new StatisticCard{Title="Bugünkü Satış Sayısı",Value= ctx.Orders.Where(x=>x.IsActive && x.Date == DateTime.Today).Count().ToString(),Icon="",BackgroundColor="#18dcff"},
                new StatisticCard{Title="Bugün Kasadaki Tutar",Value= ctx.Orders.Where(x=>x.IsActive && x.Date == DateTime.Today).ToList().Sum(x=>x.Total).ToString(),Icon="",BackgroundColor="#7d5fff"},
                new StatisticCard{Title="En Fazla Ürünü Olan Marka",Value= ctx.Products.Where(x=>x.IsActive ).GroupBy(x=>x.Brand).OrderByDescending(x=>x.Count()).Select(x=>x.Key).FirstOrDefault(),Icon="",BackgroundColor="#3ae374"},
                new StatisticCard{Title="En Az Ürünü Olan Marka",Value= ctx.Products.Where(x=>x.IsActive ).GroupBy(x=>x.Brand).OrderBy(x=>x.Count()).Select(x=>x.Key).FirstOrDefault(),Icon="",BackgroundColor="#F79F1F"},
                new StatisticCard{Title="En Fazla Satılan Ürün",Value= ctx.Products.Where(x=>x.ProductId == (ctx.Orders.GroupBy(y=>y.ProductId).OrderByDescending(z=>z.Count()).Select(q=>q.Key).FirstOrDefault())).Select(x=>x.Name).FirstOrDefault().ToString(),Icon="",BackgroundColor="#17c0eb"},
                new StatisticCard{Title="En Az Satılan Ürün",Value= ctx.Products.Where(x=>x.ProductId == (ctx.Orders.GroupBy(y=>y.ProductId).OrderBy(z=>z.Count()).Select(q=>q.Key).FirstOrDefault())).Select(x=>x.Name).FirstOrDefault().ToString(),Icon="",BackgroundColor="#7158e2"},
            };

            return View(cards);
        }

        public ActionResult SimpleTables()
        {
            
            return View();
        }

        public PartialViewResult CustomersByAddress()
        {
            var CustomersByAddress = ctx.Customers.Where(x => x.IsActive)
                .GroupBy(x => x.Address)
                .Select(y => new CustomerCityGroup
                {
                    City = y.Key,
                    Count = y.Count()
                }).ToList();
            return PartialView(CustomersByAddress);
        }

        public PartialViewResult EmployeesByDepartment()
        {
            var EmployeesByDepartment = ctx.Employees.Where(x => x.IsActive)
               .GroupBy(x => x.Department.Name)
               .Select(y => new EmployeeDepatmentGroup
               {
                   Department = y.Key,
                   Count = y.Count()
               }).ToList();
            return PartialView(EmployeesByDepartment);
        }

        public PartialViewResult ProductsByBrand()
        {
            var ProductsByBrand = ctx.Products.Where(x => x.IsActive)
               .GroupBy(x => x.Brand)
               .Select(y => new ProductBrandGroup
               {
                   Brand = y.Key,
                   Count = y.Count()
               }).ToList();
            return PartialView(ProductsByBrand);
        }

        public PartialViewResult Customers()
        {
            var customers = ctx.Customers.Where(x => x.IsActive)
             .ToList();
            return PartialView(customers);
        }

        public PartialViewResult Products()
        {
            var products = ctx.Products.Where(x => x.IsActive)
             .ToList();
            return PartialView(products);
        }

        public PartialViewResult Categories()
        {
            var categories = ctx.Categories.Where(x => x.IsActive)
             .ToList();
            return PartialView(categories);
        }

    }
}