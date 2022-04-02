using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Employee { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}