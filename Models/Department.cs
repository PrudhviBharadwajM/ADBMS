using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADBMS.Models
{
    [Table("Department")]
    public partial class Department
    {
        [Key]
        public int DeptNum { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string DeptName { get; set; } = null!;
        [Column("EmpManagerSSN")]
        public int? EmpManagerSsn { get; set; }
    }
}
