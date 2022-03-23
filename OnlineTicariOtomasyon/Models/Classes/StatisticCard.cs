using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class StatisticCard
    {
        [Key]
        public int StatisticCardId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsActive { get; set; }


    }
}