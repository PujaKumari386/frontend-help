using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("LeaveTable")]
    public partial class LeaveTable
    {
        [Key]
        [Column("Leave_id")]
        public int LeaveId { get; set; }
        [Required]
        [Column("reason", TypeName = "text")]
        public string Reason { get; set; }
        [Column("duration", TypeName = "date")]
        public DateTime Duration { get; set; }
        [Column("Student_id")]
        public int StudentId { get; set; }
        [Column("is_approved")]
        public bool IsApproved { get; set; }

        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(StudentTable.LeaveTables))]
        public virtual StudentTable Student { get; set; }
    }
}
