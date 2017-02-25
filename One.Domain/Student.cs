using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One.Domain
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        [StringLength(500)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Phone { get; set; }

        public int SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual School School { get; set; }
        public int StreemId { get; set; }
        [ForeignKey("StreemId")]
        public virtual Streem Streem { get; set; }
    }
}
