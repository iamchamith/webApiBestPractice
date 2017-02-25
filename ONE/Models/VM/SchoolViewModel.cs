using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ONE.Models.VM
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "School Name Requred")]
        public string Name { get; set; }
    }
}