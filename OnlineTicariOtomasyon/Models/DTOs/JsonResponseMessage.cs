using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.DTOs
{
    public class JsonResponseMessage
    {
        public bool hasError { get; set; }
        public string message { get; set; }
        public object data { get; set; }

    }
}