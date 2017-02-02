using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ONE.Models.VM
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Student name Requred")]
        public string Name { get; set; }
        [Required (ErrorMessage = "Student email Requred")]
        [StringLength(50,ErrorMessage ="Email Must lessthan 50 char")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalied Email Address")]
        public string Email { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Student Address Requred")]
        [StringLength(500, ErrorMessage = "Address Must lessthan 500 char")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Student Phone Requred")]
        [StringLength(10, ErrorMessage = "Phone Must lessthan 10 char")]
        public string Phone { get; set; }
    }
}