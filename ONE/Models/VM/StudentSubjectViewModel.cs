using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ONE.Models.VM
{
    public class StudentSubjectViewModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime RegDate { get; set; }
    }
}