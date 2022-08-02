using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Todo.Models
{
    public class Todolist
    {
        public int id { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        public string title { get; set; }
    }
}