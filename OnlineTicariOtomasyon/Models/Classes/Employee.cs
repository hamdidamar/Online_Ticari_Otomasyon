using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "Personel Adı")]
        public string Name { get; set; }
        [Display(Name = "Personel Soyadı")]
        public string Surname { get; set; }
        [Display(Name = "Personel Fotoğrafı")]
        public string PhotoPath { get; set; } // ileride fotoğraflar sınıfı gelince değişecek
        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }
        [Display(Name = "Personel Departmanı")]
        public virtual Department Department { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}