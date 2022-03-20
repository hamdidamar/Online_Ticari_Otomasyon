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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoPath { get; set; } // ileride fotoğraflar sınıfı gelince değişecek
        public bool IsActive { get; set; }

        public Department Department { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}