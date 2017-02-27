using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using static One.Bo.Utility.Enums;

namespace One.Domain
{
    [Table("Error")]
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Exception { get; set; }
        [Required]
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        [Required]
        public ErrorType ExceptionType { get; set; }
        [Required]
        public bool IsChecked { get; set; }
        public string Descripton { get; set; }
    }
}
