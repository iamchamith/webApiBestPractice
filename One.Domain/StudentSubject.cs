using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace One.Domain
{
    [Table("StudentSubject")]
    public class StudentSubject
    {
        [Key]
        [Column(Order =1)]
        public int StudentId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SubjectId { get; set; }
        public DateTime RegDate { get; set; }
 
        [ForeignKey("StudentId")]
        public virtual Subject Subjects { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
