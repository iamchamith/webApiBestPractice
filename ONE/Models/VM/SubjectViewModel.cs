using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ONE.Models.VM
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject Name Requred")]
        [StringLength(50, ErrorMessage = "Subject Name length must be less than 50 char")]
        public string Name { get; set; }
        [Range(100.00, 1500.00, ErrorMessage = "Subject fee must be between Rs.100-Rs.1500")]
        public double Fee { get; set; }
    }
}