using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static One.Bo.Utility.Enums;

namespace ONE.Models.VM
{
    public class ErrorViewModel
    {
        public int Id { get; set; }
        public string Exception { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public ErrorType ExceptionType { get; set; }
        public bool IsChecked { get; set; }
        public string Descripton { get; set; }
    }
}