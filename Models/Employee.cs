using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADBMS.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [Column("SSN")]
        public int Ssn { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string? MiddleName { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [Column("DOB", TypeName = "date")]
        public DateTime? Dob { get; set; }
        [StringLength(50)]
        public string EmpAddress { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string DeptNum { get; set; }
    }
}
