using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ONE.Models.VM
{
    public class StreemViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Stream Name Requred")]
        public string Name { get; set; }
    }
}