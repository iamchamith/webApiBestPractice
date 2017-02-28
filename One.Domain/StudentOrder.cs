using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;

namespace One.Domain
{
    [Table("StudentOrder")]
    public class StudentOrder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EntityId { get; set; }
    }
}
