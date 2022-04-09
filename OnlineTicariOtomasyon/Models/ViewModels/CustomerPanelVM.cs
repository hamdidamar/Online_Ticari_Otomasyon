using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.ViewModels
{
    public class CustomerPanelVM
    {
        public CustomerPanelVM()
        {
            this.Customer = new Customer();
            this.Messages = new List<Message>();
            this.Orders = new List<Order>();
        }
        public Customer Customer { get; set; }
        public List<Message> Messages { get; set; }
        public List<Order> Orders { get; set; }

    }
}