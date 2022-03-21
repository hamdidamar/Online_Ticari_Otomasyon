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

    }
}