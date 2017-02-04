using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using static One.Bo.Utility.Enums;

namespace One.Domain
{
    [Table("UserAuthontication")]
    public class UserAuthontication
    {
        [Key]
        public string UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public EUserRole Role { get; set; }
    }
}
