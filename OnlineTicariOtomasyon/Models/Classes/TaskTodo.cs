using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class TaskTodo
    {
        [Key]
        public int ToDoId { get; set; }
        public string Title { get; set; }
        public bool State { get; set; }
        public bool IsActive { get; set; }
    }
}