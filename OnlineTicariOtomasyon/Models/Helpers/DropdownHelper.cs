using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Models.Helpers
{
    public class DropdownHelper
    {
        Context ctx;
        public DropdownHelper()
        {
            ctx = new Context();
        }

        public List<SelectListItem> GetCategories(Expression<Func<Category, bool>> filter = null)
        {
            if (filter != null)
            {
                return (from x in ctx.Categories.Where(filter).Where(x=>x.IsActive).ToList()
                        select new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.CategoryId.ToString()
                        }).ToList();
            }
            return (from x in ctx.Categories.Where(x => x.IsActive).ToList()
                    select new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.CategoryId.ToString()
                    }).ToList();

        }

        public List<SelectListItem> GetDepartments(Expression<Func<Department, bool>> filter = null)
        {
            if (filter != null)
            {
                return (from x in ctx.Departments.Where(filter).Where(x => x.IsActive).ToList()
                        select new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.DepartmentId.ToString()
                        }).ToList();
            }
            return (from x in ctx.Departments.Where(x => x.IsActive).ToList()
                    select new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.DepartmentId.ToString()
                    }).ToList();

        }

        public List<SelectListItem> GetProducts(Expression<Func<Product, bool>> filter = null)
        {
            if (filter != null)
            {
                return (from x in ctx.Products.Where(filter).Where(x => x.IsActive && x.Stock >0).ToList()
                        select new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.ProductId.ToString()
                        }).ToList();
            }
            return (from x in ctx.Products.Where(x => x.IsActive && x.Stock > 0).ToList()
                    select new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.ProductId.ToString()
                    }).ToList();

        }

        public List<SelectListItem> GetCustomers(Expression<Func<Customer, bool>> filter = null)
        {
            if (filter != null)
            {
                return (from x in ctx.Customers.Where(filter).Where(x => x.IsActive).ToList()
                        select new SelectListItem
                        {
                            Text = x.Name + " "+x.Surname,
                            Value = x.CustomerId.ToString()
                        }).ToList();
            }
            return (from x in ctx.Customers.Where(x => x.IsActive).ToList()
                    select new SelectListItem
                    {
                        Text = x.Name + " " + x.Surname,
                        Value = x.CustomerId.ToString()
                    }).ToList();

        }

        public List<SelectListItem> GetEmployees(Expression<Func<Employee, bool>> filter = null)
        {
            if (filter != null)
            {
                return (from x in ctx.Employees.Where(filter).Where(x => x.IsActive).ToList()
                        select new SelectListItem
                        {
                            Text = x.Name + " " + x.Surname,
                            Value = x.EmployeeId.ToString()
                        }).ToList();
            }
            return (from x in ctx.Employees.Where(x => x.IsActive).ToList()
                    select new SelectListItem
                    {
                        Text = x.Name + " " + x.Surname,
                        Value = x.EmployeeId.ToString()
                    }).ToList();

        }

        //Cascading kodları
//        <script>

//    $(function () {

//        $('#DrpSehir').change(function () {

//            var id = $('#DrpSehir').val();

//            $.ajax({

//            url: '/Home/ilcegetir',

//                data: { p: id },

//                type: "POST",

//                dataType: "Json",

//                success: function(data) {

//                    console.log(data);

//                    $('#Drpilce').empty();

//                    for (var i = 0; i < data.length; i++)
//                    {

//                        $('#Drpilce').append("<option value='" + data[i].Value + "'>" + data[i].Text + "</Option>");

//                    }

//                }

//            });

//        });

//    });

//</script>
    }
}